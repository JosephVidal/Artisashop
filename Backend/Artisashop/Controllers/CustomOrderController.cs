namespace Artisashop.Controllers;

using System.Net;
using Artisashop.Helpers;
using Artisashop.Models;
using Models.Enums;
using Artisashop.Models.ViewModel;
using Artisashop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Artisashop.Models.BasketItem;

[ApiController]
[Produces("application/json")]
[Route("api/custom-order/")]
[Authorize]
public class CustomOrderController : ControllerBase
{
    private readonly StoreDbContext _db;

    public CustomOrderController(StoreDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Displays the product list with their actual state
    /// </summary>
    /// <returns>Craftsman commands page</returns>
    [HttpGet("list")]
    [Authorize(Roles = "CRAFTSMAN")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(List<OrderList>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> OrderList()
    {
        try
        {
            // Account account = await _randomUtils.GetFromCookie(Request, _db);
            //
            // List<OrderList> tmpList = await _db.Baskets!.Include("Product.Craftsman")
            //     .Where(basket => basket.Product!.Craftsman!.Id == account.Id)
            //     .Select(x =>
            //         new OrderList(x, NextDeliveryStates.GetNextDeliveryStates(x.CurrentState, x.DeliveryOpt)))
            //     .ToListAsync();
            // return Ok(tmpList);

            // TODO: FIX
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Display the custom command formular
    /// </summary>
    /// <param name="craftsmanId">Id of the craftsman to link with the command</param>
    /// <returns>Custom command page on success, redirect to AccountController::Login if not logged in or BadRequest</returns>
    [HttpGet("{craftsmanId}")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(Account), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCreate(string craftsmanId)
    {
        try
        {
            Account? account = await _db.Users!.SingleOrDefaultAsync(account => account.Id == craftsmanId);

            if (account == null)
                return NotFound("Account with id " + craftsmanId + " not found");
            return Ok(account);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Creates a custom command for the user
    /// </summary>
    /// <param name="order">Model containing craftsman id and command info</param>
    /// <returns>Redirect to ChatController::Chat on success, AccountController::Login if not logged in or BadRequest</returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BasketItem), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create(CreateCustomOrder order)
    {
        try
        {
            // Account account = await _randomUtils.GetFromCookie(Request, _db);
            // Account? craftsman = await _db.Users!.SingleOrDefaultAsync(account => account.Id == order.CraftsmanId);
            //
            // if (craftsman == null)
            //     return NotFound("Craftsman with id " + order.CraftsmanId + " not found");
            //
            // var styles = await CreateStyles(order.Styles);
            //
            // Product product =
            //     new Product()
            //     {
            //         Name = order.Name,
            //         Description = order.Description,
            //         Price = order.Price,
            //         Quantity = order.Quantity,
            //         CraftsmanId = order.CraftsmanId,
            //         Styles = styles.Select(s => new ProductStyle() { Style = s }).ToList(),
            //     };
            //
            // Basket basket = new Basket()
            // {
            //     Account = account,
            //     Product = product,
            //     Quantity = order.Quantity,
            //     DeliveryOpt = DeliveryOption.DELIVERY,
            //     CurrentState = DeliveryState.WAITINGCRAFTSMAN,
            //     PossibleState = NextDeliveryStates
            //         .GetNextDeliveryStates(DeliveryState.WAITINGCRAFTSMAN, DeliveryOption.DELIVERY)
            //         .Select(ds => new BasketPossibleState() { DeliveryState = ds })
            //         .ToList(),
            // };
            //
            // await _db.Baskets!.AddAsync(basket);
            // await _db.SaveChangesAsync();
            // return Ok(basket);
            
            // TODO: FIX
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Display custom command update formular
    /// </summary>
    /// <param name="basketId">BasketId of the command to update</param>
    /// <returns>Update command page on success, redirect AccountController::Login if not logged in or BadRequest</returns>
    [HttpGet("update/{basketId}")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(BasketItem), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetUpdate(int basketId)
    {
        try
        {
            BasketItem? basket = await _db.Baskets!.Include("Product.Craftsman")
                .SingleOrDefaultAsync(basket => basket.Id == basketId);

            if (basket == null)
                return NotFound("Basket item with id " + basketId + " not found");
            return Ok(basket);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Update a custom command
    /// </summary>
    /// <param name="model">Updated fields for command update</param>
    /// <returns>Redirect to ChatController::Chat on success, AccountController::Login if not logged in or BadRequest</returns>
    [HttpPatch]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BasketItem), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update([FromBody] UpdateCustomOrder model)
    {
        try
        {
            BasketItem? basket = await _db.Baskets!.Include("Product")
                .FirstOrDefaultAsync(basket => basket.Id == model.Id);

            if (basket == null)
                return NotFound("Basket with id " + model.Id + " not found");

            basket.Quantity = model.Quantity == null ? basket.Quantity : (int)model.Quantity;
            basket.DeliveryOpt = model.DeliveryOpt == null ? basket.DeliveryOpt : (DeliveryOption)model.DeliveryOpt;
            basket.Product!.Name = model.Name == null ? basket.Product.Name : model.Name;
            basket.Product!.Description =
                model.Description == null ? basket.Product.Description : model.Description;
            basket.Product!.Price = model.Price == null ? basket.Product.Price : model.Price;
            basket.Product!.Quantity = model.Quantity == null ? basket.Product.Quantity : (int)model.Quantity;
            _db.Baskets!.Update(basket);
            await _db.SaveChangesAsync();
            return Ok(basket);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// This function change the status of a customer command in the basket
    /// </summary>
    /// <param name="basketId">Basket of the user link to the command</param>
    /// <param name="state">State to apply</param>
    /// <returns>200 on success, 403 on fail</returns>
    [HttpPatch("{basketId}/changeStatus")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(DeliveryState), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateStatus(int basketId, DeliveryState state)
    {
        try
        {
            BasketItem? basket = await _db.Baskets!.FirstAsync(basket => basket.Id == basketId);
            basket.CurrentState = state;
            _db.Baskets!.Update(basket);
            await _db.SaveChangesAsync();
            return Ok(state);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Creates styles if they don't exist, and returns the entire list.
    /// TODO: regroup duplicate code
    /// </summary>
    /// <param name="styles"></param>
    /// <returns></returns>
    private async Task<List<Style>> CreateStyles(List<string> styles)
    {
        var oldStyles = _db.Styles.Where(s => styles.Contains(s.Name));
        var newStyles = styles.Where(s => !oldStyles.Any(st => st.Name == s))
            .Select(s => new Style() { Name = s }).ToList();
        await _db.Styles.AddRangeAsync(newStyles);
        await _db.SaveChangesAsync();

        return await _db.Styles.Where(s => styles.Contains(s.Name)).ToListAsync();
    }
}