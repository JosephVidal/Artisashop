using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Artisashop.Models;
using Artisashop.Models.ViewModel;
using Artisashop.Services;
using static Artisashop.Models.Basket;

namespace Artisashop.Controllers
{
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
        private readonly Utils _utils = new();

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
                Account account = await _utils.GetFromCookie(Request, _db);
                List<Basket> basket = await _db.Baskets!.Include(basket => basket.Product).Where(basket => basket.AccountId == account.Id && basket.CurrentState == Basket.State.WAITINGCONSUMER).ToListAsync();

                foreach (Basket elem in basket)
                {
                    Account? craftsman = await _db.Accounts!.FirstOrDefaultAsync(account => account.Id == elem.Product!.CraftsmanId!);
                    if (craftsman == null)
                        return BadRequest("Craftman missing in product: " + elem.Product!.Id);
                    elem.Product!.Craftsman = craftsman;
                }
                return Ok(basket);
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
                Account account = await _utils.GetFromCookie(Request, _db);
                Basket? basket = await _db.Baskets!.Include("Product").FirstOrDefaultAsync(basket => basket.AccountId == account.Id && basket.CurrentState == Basket.State.WAITINGCONSUMER && basket.ProductId == productID);

                if (basket != null)
                {
                    basket.Quantity = quantityModifier;
                    return RedirectToAction("Update", basket);
                }

                Product product = await _db.Products!.SingleAsync(product => product.Id == productID);

                basket = (await _db.Baskets!.AddAsync(new(account, product, Math.Min(quantityModifier, product.Quantity), Basket.DeliveryOption.DELIVERY, Basket.State.WAITINGCONSUMER,
                    Enum.GetValues(typeof(Basket.State)).Cast<Basket.State>().ToList()))).Entity;

                await _db.SaveChangesAsync();
                return Ok(basket);
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
                Basket? basket = await _db.Baskets!.Include("Product").FirstOrDefaultAsync(basket => basket.Id == model.Id);

                if (basket == null)
                    return NotFound("Basket with id " + model.Id + " not found");
                basket.Quantity = model.Quantity != null ? Math.Min((int)model.Quantity, basket.Product!.Quantity) : basket.Product!.Quantity;
                basket.CurrentState = model.CurrentState != null ? (Basket.State)model.CurrentState : basket.CurrentState;
                basket.DeliveryOpt = model.DeliveryOpt != null ? (Basket.DeliveryOption)model.DeliveryOpt : basket.DeliveryOpt;
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
        public async Task<IActionResult> Payement([FromBody] string address)
        {
            try
            {
                if (address == "")
                    return BadRequest("Adresse Invalide");

                Account account = await _utils.GetFromCookie(Request, _db);
                List<Basket> basket = await _db.Baskets!.Include(basket => basket.Product).Where(basket => basket.AccountId == account.Id && (basket.CurrentState == Basket.State.WAITINGCONSUMER || basket.CurrentState == Basket.State.WAITINGCRAFTSMAN)).ToListAsync();
                double totPrice = 0;

                if (basket.Count == 0)
                    return NotFound("No basket item found");
                foreach (Basket elem in basket)
                    totPrice += (double)elem.Product!.Price! * elem.Quantity + (elem.DeliveryOpt == Basket.DeliveryOption.DELIVERY ? 20 : 0);
                return Ok(new { basket, address, totPrice });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
