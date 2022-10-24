using Backend.Models;
using Backend.Models.ViewModel;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Backend.Models.Basket;

namespace Backend.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/custom-order/")]
    [Authorize]
    public class CustomOrderController : ControllerBase
    {
        private readonly StoreDbContext _db;
        private readonly Utils _utils = new();

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
                Account account = await _utils.GetFromCookie(Request, _db);

                List<Basket> tmpList = await _db.Baskets!.Include("Product.Craftsman").Where(basket => basket.Product!.Craftsman!.Id == account.Id).ToListAsync();
                var cmdList = new List<OrderList>();
                foreach (Basket item in tmpList)
                    cmdList.Add(new OrderList(item, GenPossibleState(item.CurrentState, item.DeliveryOpt)));
                return Ok(cmdList);
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
                Account? account = await _db.Accounts!.SingleOrDefaultAsync(account => account.Id == craftsmanId);

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
        [ProducesResponseType(typeof(Basket), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(CreateCustomOrder order)
        {
            try
            {
                Account account = await _utils.GetFromCookie(Request, _db);
                Account? craftsman = await _db.Accounts!.SingleOrDefaultAsync(account => account.Id == order.CraftsmanId);

                if (craftsman == null)
                    return NotFound("Craftsman with id " + order.CraftsmanId + " not found");

                Product product = new(order.Name, craftsman, 0, order.Desc, order.Quantity, new List<string> { "/img/Product/default.png" });
                Basket basket = new(account, product, order.Quantity, DeliveryOption.DELIVERY, State.WAITINGCRAFTSMAN, GenPossibleState(State.WAITINGCRAFTSMAN, DeliveryOption.DELIVERY));
                await _db.Baskets!.AddAsync(basket);
                await _db.SaveChangesAsync();
                return Ok(basket);
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
        [HttpGet("update/{basketID}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Basket), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUpdate([FromQuery] int basketId)
        {
            try
            {
                Basket? basket = await _db.Baskets!.Include("Product.Craftsman").SingleOrDefaultAsync(basket => basket.Id == basketId);

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
        [ProducesResponseType(typeof(Basket), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] UpdateCustomOrder model)
        {
            try
            {
                Basket? basket = await _db.Baskets!.Include("Product").FirstOrDefaultAsync(basket => basket.Id == model.Id);

                if (basket == null)
                    return NotFound("Basket with id " + model.Id + " not found");

                basket.Quantity = model.Quantity == null ? basket.Quantity : (int)model.Quantity;
                basket.DeliveryOpt = model.DeliveryOpt == null ? basket.DeliveryOpt : (DeliveryOption)model.DeliveryOpt;
                basket.Product!.Name = model.Name == null ? basket.Product.Name : model.Name;
                basket.Product!.Description = model.Description == null ? basket.Product.Description : model.Description;
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
        [ProducesResponseType(typeof(State), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateStatus(int basketId, State state)
        {
            try
            {
                Basket? basket = await _db.Baskets!.FirstAsync(basket => basket.Id == basketId);
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
        /// Generating possible command state regading its actual state
        /// </summary>
        /// <param name="state">The actual command state</param>
        /// <param name="delOpt">Delivery option choosen</param>
        /// <returns>List of state possible</returns>
        private static List<State> GenPossibleState(State state, DeliveryOption delOpt)
        {
            switch (state)
            {
                case State.WAITINGCRAFTSMAN:
                    return new List<State> { State.REFUSED/*, State.WAITINGCONSUMER*/ };
                case State.VALIDATED:
                    if (DeliveryOption.TAKEOUT == delOpt)
                        return new List<State> { State.ONGOING, State.DELIVERY, State.END };
                    else
                        return new List<State> { State.ONGOING, State.END };
                case State.ONGOING:
                    if (DeliveryOption.TAKEOUT == delOpt)
                        return new List<State> { State.DELIVERY, State.END };
                    else
                        return new List<State> { State.END };
                case State.DELIVERY:
                    return new List<State> { State.END };
                case State.WAITINGCONSUMER:
                case State.REFUSED:
                case State.END:
                default:
                    return new List<State>();
            }
        }
    }
}
