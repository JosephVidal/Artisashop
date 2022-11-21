namespace Artisashop.Controllers;

using System.Net;
using Artisashop.Helpers;
using Artisashop.Models;
using Artisashop.Models.Enum;
using Artisashop.Models.ViewModel;
using Artisashop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Artisashop.Models.Basket;

/// <summary>
/// This function handles basket actions and custom commands
/// </summary>
[ApiController]
[Produces("application/json")]
[Route("api/basket/")]
[Authorize]
public class BasketController : ControllerBase
{
    private readonly StoreDbContext _db;

    public BasketController(StoreDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Display the basket for consumers
    /// </summary>
    /// <returns>Basket page, redirect to AccountController::Account or BadRequest</returns>
    [HttpGet]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(List<Basket>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Index()
    {
        try
        {
            // Account account = await Utils.GetFromCookie(Request, _db);
            // List<Basket> basket = await _db.Baskets
                // .Include(basket => basket.Product)
                // .Where(basket =>
                    // basket.AccountId == account.Id && basket.CurrentState == DeliveryState.WAITINGCONSUMER)
                // .ToListAsync();

            // foreach (Basket elem in basket)
            // {
                // Account? craftsman =
                    // await _db.Users!.FirstOrDefaultAsync(account => account.Id == elem.Product!.CraftsmanId!);
                // if (craftsman == null)
                    // return BadRequest("Craftman missing in product: " + elem.Product!.Id);
                // elem.Product!.Craftsman = craftsman;
            // }

            // return Ok(basket);
            
            //TODO: Implement basket
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Modify the quantity for a product in the basket
    /// </summary>
    /// <param name="productID">Id of the product in the basket</param>
    /// <param name="quantityModifier">Quantity modified</param>
    /// <returns>Content updated in page or error 403</returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Redirect)]
    [ProducesResponseType(typeof(Basket), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add([FromQuery] int productID, [FromQuery] int quantityModifier)
    {
        try
        {
            // Account account = await _randomUtils.GetFromCookie(Request, _db);
            // var basket = await _db.Baskets
            //     .Include("Product")
            //     .FirstOrDefaultAsync(basket =>
            //         basket.AccountId == account.Id && basket.CurrentState == DeliveryState.WAITINGCONSUMER &&
            //         basket.ProductId == productID);
            //
            // if (basket != null)
            // {
            //     basket.Quantity = quantityModifier;
            //     return RedirectToAction("Update", basket);
            // }
            //
            // Product product = await _db.Products!.SingleAsync(product => product.Id == productID);
            //
            // var newBasket = new Basket()
            // {
            //     Account = account,
            //     Product = product,
            //     Quantity = Math.Min(quantityModifier, product.Quantity),
            //     DeliveryOpt = DeliveryOption.DELIVERY,
            //     CurrentState = DeliveryState.WAITINGCONSUMER,
            //     PossibleState = NextDeliveryStates
            //         .GetNextDeliveryStates(DeliveryState.WAITINGCONSUMER, DeliveryOption.DELIVERY)
            //         .Select(x => new BasketPossibleState() { DeliveryState = x })
            //         .ToList(),
            // };
            //
            // var elem = await _db.Baskets.AddAsync(newBasket);
            //
            // await _db.SaveChangesAsync();
            // return Ok(elem.Entity);
            
            // TODO: Implement basket
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Modify the quantity for a product in the basket
    /// </summary>
    /// <param name="productID">Id of the product in the basket</param>
    /// <param name="quantityModifier">Quantity modified</param>
    /// <returns>Content updated in page or error 403</returns>
    [HttpPatch]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(Basket), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update([FromBody] UpdateBasket model)
    {
        try
        {
            Basket? basket = await _db.Baskets!.Include("Product")
                .FirstOrDefaultAsync(basket => basket.Id == model.Id);

            if (basket == null)
                return NotFound("Basket with id " + model.Id + " not found");
            basket.Quantity = model.Quantity != null
                ? Math.Min((int)model.Quantity, basket.Product!.Quantity)
                : basket.Product!.Quantity;
            basket.CurrentState = model.CurrentState != null ? (DeliveryState)model.CurrentState : basket.CurrentState;
            basket.DeliveryOpt = model.DeliveryOpt != null ? (DeliveryOption)model.DeliveryOpt : basket.DeliveryOpt;
            if (basket.Quantity > 0)
                _db.Baskets!.Update(basket);
            else
                _db.Baskets!.Remove(basket);
            await _db.SaveChangesAsync();
            return Ok(basket);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Delete an product from the basket
    /// </summary>
    /// <param name="basketId">Id of the product in the basket</param>
    /// <returns>Nothing on success or error 403</returns>
    [HttpDelete("{basketId}")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(int basketId)
    {
        try
        {
            Basket? basket = await _db.Baskets!.FirstAsync(basket => basket.Id == basketId);

            if (basket == null)
                return NotFound("Basket item with id " + basketId + " not found");
            _db.Baskets!.Remove(basket);
            await _db.SaveChangesAsync();
            return Ok("Basket item with id " + basketId + " not found");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// This function displays the checkout and show payment means
    /// </summary>
    /// <param name="address">Adress where to send the products</param>
    /// <returns>Payement page, CustomError page on empty address, AccountController::Login if not logged in or BadRequest</returns>
    [HttpGet("pay")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof((List<Basket>, string, double)), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Payment([FromBody] string address)
    {
        try
        {
            if (address == "")
                return BadRequest("Adresse Invalide");

            // Account account = await _randomUtils.GetFromCookie(Request, _db);
            // List<Basket> basket = await _db.Baskets!.Include(basket => basket.Product).Where(basket =>
            //         basket.AccountId == account.Id && (basket.CurrentState == DeliveryState.WAITINGCONSUMER ||
            //                                            basket.CurrentState == DeliveryState.WAITINGCRAFTSMAN))
            //     .ToListAsync();
            // double totPrice = 0;
            //
            // if (basket.Count == 0)
            //     return NotFound("No basket item found");
            // foreach (Basket elem in basket)
            //     totPrice += (double)elem.Product!.Price! * elem.Quantity +
            //                 (elem.DeliveryOpt == DeliveryOption.DELIVERY ? 20 : 0);
            // return Ok(new { basket, address, totPrice });
            
            // TODO: Implement basket
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}