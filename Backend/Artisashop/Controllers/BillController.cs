namespace Artisashop.Controllers;

using System.Diagnostics;
using System.Net;
using Artisashop.Interfaces.IService;
using Artisashop.Models;
using Artisashop.Models.Enum;
using Artisashop.Models.ViewModel;
using Artisashop.Services;
using Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Artisashop.Models.Basket;

[ApiController]
[Authorize]
[Produces("application/json")]
[Route("api/bill/")]
public class BillController : ControllerBase
{
    private readonly IMailService _mailService;
    private readonly StoreDbContext _db;
    private readonly Utils _utils = new();

    public BillController(IMailService mailService, StoreDbContext db)
    {
        _mailService = mailService;
        _db = db;
    }

    /// <summary>
    /// This function handles paypal payment and serializes data
    /// </summary>
    /// <returns>Serialized paypall bill or error 403</returns>
    [HttpGet]
    [ProducesResponseType(typeof(PaypalBill), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> BasketToPaypalBill()
    {
        try
        {
            Account account = await _utils.GetFromCookie(Request, _db);
            List<Basket> basket = await _db.Baskets!.Where(basket =>
                    basket.AccountId == account.Id && (basket.CurrentState == DeliveryState.WAITINGCONSUMER ||
                                                       basket.CurrentState == DeliveryState.WAITINGCRAFTSMAN))
                .ToListAsync();
            PaypalBill paypalBill = new();
            PaypalBill.PurchaseUnitElem tmpPUE = new();
            double tot = 0;

            foreach (Basket basketElem in basket)
            {
                var product = await _db.Products!.SingleAsync(product => product.Id == basketElem.ProductId);
                if (product == null)
                    return BadRequest("Product id not found: " + basketElem.ProductId);
                basketElem.Product = product;
                tmpPUE.Items!.Add(new(basketElem.Product.Name!, basketElem.Product.Description, basketElem.Quantity,
                    "EUR", (double)basketElem.Product.Price!));
                tot += (double)basketElem.Product.Price! * basketElem.Quantity;
            }

            tmpPUE.Amount = new("EUR", tot);
            paypalBill.PurchaseUnits.Add(tmpPUE);
            return Ok(paypalBill);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Clean basket after transaction and send a confirmation mail
    /// </summary>
    /// <returns>200 on success, error 403 if not logged in or 500 on fail</returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(List<Bill>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> BasketSold()
    {
        try
        {
            Account account = await _utils.GetFromCookie(Request, _db);

            List<Basket> basket = await _db.Baskets!.Include("Product.Craftsman").Where(basket =>
                basket.AccountId == account.Id && basket.CurrentState == DeliveryState.WAITINGCONSUMER).ToListAsync();
            List<string> craftsmanIDs = new();
            List<Bill> bills = new();
            foreach (Basket item in basket)
            {
                Account? craftsman = await _db.Users!.SingleAsync(account => account.Id == item.Product!.CraftsmanId!);
                if (craftsman == null)
                    return BadRequest("Craftsman not found, id: " + item.Product!.CraftsmanId);
                Bill tmp = new(craftsman.Firstname + " " + craftsman.Lastname,
                    account.Firstname + " " + account.Lastname,
                    item.Product!.Name!,
                    item.Quantity,
                    (double)item.Product.Price! * item.Quantity);
                bills.Add(tmp);
                await _db.Bills!.AddAsync(tmp);
                item.Product.Quantity += 0 - item.Quantity;
                item.CurrentState = DeliveryState.VALIDATED;
                _db.Update(item);
                if (!craftsmanIDs.Contains(item.Product.CraftsmanId!))
                    craftsmanIDs.Add(item.Product.CraftsmanId!);
            }

            try
            {
                foreach (string craftsmanID in craftsmanIDs)
                {
                    Account? craftsman = await _db.Users!.SingleAsync(account => account.Id == craftsmanID);
                    if (craftsman == null)
                        return BadRequest("Craftsman account not found, id: " + craftsmanID);
                    List<Basket> tmpBasket = basket.FindAll(x => x.Product.CraftsmanId == craftsmanID);
                    _mailService.SendMail(craftsman.Email, "Artisashop - You have sold an item",
                        MailTemplates.ItemSold(account, tmpBasket));
                }

                _mailService.SendMail(account.Email, "Artisashop - You have bought an item",
                    MailTemplates.ItemBought(bills));
            }
            catch (Exception)
            {
                Debug.WriteLine("BasketSold - email not send");
            }

            await _db.SaveChangesAsync();
            return Ok(bills);
        }
        catch (Exception e)
        {
            Debug.WriteLine("BasketSold - " + e.Message);
            Debug.WriteLine("BasketSold - basket not sold");
            return BadRequest(e.Message);
        }
    }
}