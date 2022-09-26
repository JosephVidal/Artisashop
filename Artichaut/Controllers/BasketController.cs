using Artichaut.Interfaces.IService;
using Artichaut.Models;
using Artichaut.Models.ViewModel;
using Artichaut.Services;
using Artichaut.Services.MailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using static Artichaut.Models.Basket;

namespace Artichaut.Controllers
{
    /// <summary>
    /// This function handles basket actions and custom commands
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/basket")]
    [Authorize]
    public class BasketController : ControllerBase
    {
        private readonly IMailService _mailService;
        private readonly StoreDbContext _db;
        private readonly Utils _utils = new Utils();

        public BasketController(IMailService mailService, StoreDbContext db)
        {
            _mailService = mailService;
            _db = db;
        }

        #region consumer
        /// <summary>
        /// Display the basket for consumers
        /// </summary>
        /// <returns>Basket page, redirect to AccountController::Account or BadRequest</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Index()
        {
            try
            {
                string? token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);
                var username = jwt.Claims.First(claim => claim.Type == "sub").Value;
                var user = await _db.Accounts!.SingleAsync(u => u.UserName == username);
                var basket = await _db.Baskets!.Include(basket => basket.Product).Where(basket => basket.AccountId == user.Id && basket.CurrentState == State.WAITINGCONSUMER).ToListAsync();

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
        /// This function is updating delivery info for each basket element
        /// </summary>
        /// <returns>Updated basket page, error message if it fails, redirect to AccountController::Login if not logged in or BadRequest</returns>
        [HttpGet("refresh")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeliveryInfo()
        {
            try
            {
                string? token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);
                var username = jwt.Claims.First(claim => claim.Type == "sub").Value;
                var user = await _db.Accounts!.SingleAsync(u => u.UserName == username);
                var basket = await _db.Baskets!.Include(basket => basket.Product).Where(basket => basket.AccountId == user.Id && basket.CurrentState == State.WAITINGCONSUMER).ToListAsync();

                if (basket.Count == 0)
                    return NotFound("Panier vide");
                return Ok(basket);
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
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Payement(string address)
        {
            try
            {
                if (address == null || address == "")
                    return BadRequest("Adresse Invalide");
                string? token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);
                var username = jwt.Claims.First(claim => claim.Type == "sub").Value;
                var user = await _db.Accounts!.SingleAsync(u => u.UserName == username);
                var basket = await _db.Baskets!.Include(basket => basket.Product).Where(basket => basket.AccountId == user.Id && basket.CurrentState == State.WAITINGCONSUMER).ToListAsync();
                double totPrice = 0;

                foreach (Basket elem in basket)
                    totPrice += (double)elem.Product!.Price! * elem.Quantity + (elem.DeliveryOpt == DeliveryOption.DELIVERY ? 20 : 0);
                return Ok(new { basket, address, totPrice });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Update user basket product list
        /// </summary>
        /// <returns>ContentResult or error 403</returns>
        [HttpPost("refresh")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> ListJSON()
        {
            try
            {
                string? token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);
                var username = jwt.Claims.First(claim => claim.Type == "sub").Value;
                var user = await _db.Accounts!.SingleAsync(u => u.UserName == username);
                return Ok(await _db.Baskets!.Include(basket => basket.Product).Where(basket => basket.AccountId == user.Id && basket.CurrentState == State.WAITINGCONSUMER).ToListAsync());
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
        [HttpPut("updateQuantity")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> ModifyItemQuantity(int productID, int quantityModifier)
        {
            try
            {
                string? token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);
                var username = jwt.Claims.First(claim => claim.Type == "sub").Value;
                Account account = await _db.Accounts!.SingleAsync(u => u.UserName == username);
                Product product = await _db.Products!.SingleAsync(product => product.Id == productID);
                Basket? basket = await _db.Baskets!.FirstOrDefaultAsync(basket => basket.AccountId == account.Id && basket.CurrentState == State.WAITINGCONSUMER && basket.ProductId == productID);

                if (basket == null)
                {
                    if (quantityModifier > 0)
                    {
                        await _db.Baskets!.AddAsync(new(account, product, quantityModifier, DeliveryOption.DELIVERY, State.WAITINGCONSUMER,
                            Enum.GetValues(typeof(State)).Cast<State>().ToList()));
                    }
                    await _db.SaveChangesAsync();
                    return Ok(Math.Min(quantityModifier, product.Quantity));
                }
                else
                {
                    basket.Quantity = Math.Min(basket.Quantity + quantityModifier, product.Quantity);
                    if (basket.Quantity > 0)
                        _db.Baskets!.Update(basket);
                    else
                        _db.Baskets!.Remove(basket);
                    await _db.SaveChangesAsync();
                    return Ok(basket.Quantity);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Modifies the delivery option for a product in the basket
        /// </summary>
        /// <param name="productID">Id of the product in the basket</param>
        /// <param name="deliveryOptMod">Delivery option selected</param>
        /// <returns>Content updated in page or error 403</returns>
        [HttpPut("updateDelivery")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> ModifyItemDeliveryOpt(int productID, DeliveryOption deliveryOptMod)
        {
            try
            {
                string? token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);
                var username = jwt.Claims.First(claim => claim.Type == "sub").Value;
                Account user = await _db.Accounts!.SingleAsync(u => u.UserName == username);
                List<Basket> tmpList = _db.Baskets!.Where(basket => basket.AccountId == user.Id && basket.CurrentState == State.WAITINGCONSUMER && basket.ProductId == productID).ToList();

                if (tmpList.Count == 0)
                    return Ok(deliveryOptMod);
                else
                {
                    Basket item = tmpList[0];
                    _db.Baskets!.Remove(item);
                    await _db.SaveChangesAsync();
                    return Ok(deliveryOptMod);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Delete an product from the basket
        /// </summary>
        /// <param name="productID">Id of the product in the basket</param>
        /// <returns>Nothing on success or error 403</returns>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteItem(int productID)
        {
            try
            {
                Account account = await _utils.GetFromCookie(Request, _db);

                List<Basket> tmpList = _db.Baskets!.Where(basket => basket.AccountId == account.Id && basket.CurrentState == State.WAITINGCONSUMER && basket.ProductId == productID).ToList();
                if (tmpList.Count != 0)
                {
                    Basket item = tmpList[0];
                    _db.Baskets!.Remove(item);
                    await _db.SaveChangesAsync();
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// This function handles paypal payment and serializes data
        /// </summary>
        /// <returns>Serialized paypall bill or error 403</returns>
        [HttpGet("bill")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> BasketToPaypalBill()
        {
            try
            {
                Account account = await _utils.GetFromCookie(Request, _db);

                List<Basket> basket = await _db.Baskets!.Where(basket => basket.AccountId == account.Id && basket.CurrentState == State.WAITINGCONSUMER).ToListAsync();
                PaypalBillViewModel paypalBill = new();
                PaypalBillViewModel.PurchaseUnitElem tmpPUE = new();
                double tot = 0;
                foreach (Basket basketElem in basket)
                {
                    var product = await _db.Products!.SingleAsync(product => product.Id == basketElem.ProductId);
                    if (product == null)
                        return BadRequest("Product id not found: " + basketElem.ProductId);
                    basketElem.Product = product;
                    tmpPUE.Items.Add(new(basketElem.Product.Name!, basketElem.Product.Description, basketElem.Quantity, "EUR", (double)basketElem.Product.Price!));
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
        [HttpPost("bill")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> BasketSold()
        {
            try
            {
                Account account = await _utils.GetFromCookie(Request, _db);

                List<Basket> basket = await _db.Baskets!.Where(basket => basket.AccountId == account.Id && basket.CurrentState == State.WAITINGCONSUMER).ToListAsync();
                List<string> craftsmanIDs = new();
                List<Bill> bills = new();
                foreach (Basket item in basket)
                {
                    Account? craftsman = await _db.Accounts!.SingleAsync(account => account.Id == item.Product!.CraftsmanId!);
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
                    item.CurrentState = State.VALIDATED;
                    _db.Update(item);
                    if (!craftsmanIDs.Contains(item.Product.CraftsmanId!))
                        craftsmanIDs.Add(item.Product.CraftsmanId!);
                }
                try
                {
                    foreach (string craftsmanID in craftsmanIDs)
                    {
                        Account? craftsman = await _db.Accounts!.SingleAsync(account => account.Id == craftsmanID);
                        if (craftsman == null)
                            return BadRequest("Craftsman account not found, id: " + craftsmanID);
                        List<Basket> tmpBasket = basket.FindAll(x => x.Product.CraftsmanId == craftsmanID);
                        _mailService.SendMail(craftsman.Email, "Artisashop - You have sold an item", MailTemplates.ItemSold(account, tmpBasket));
                    }
                    _mailService.SendMail(account.Email, "Artisashop - You have bought an item", MailTemplates.ItemBought(bills));
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
        #endregion

        #region craftsman
        /// <summary>
        /// Displays the product list with their actual state
        /// </summary>
        /// <returns>Craftsman commands page</returns>
        [HttpGet("order")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CraftsmanCmdList()
        {
            try
            {
                Account account = await _utils.GetFromCookie(Request, _db);

                List<Basket> tmpList = await _db.Baskets!.Include("Basket.Product.Craftsman").Where(basket => basket.Product!.Craftsman!.Id == account.Id).ToListAsync();
                var cmdList = new List<CmdListViewModel>();
                foreach (Basket item in tmpList)
                    cmdList.Add(new CmdListViewModel(item, GenPossibleState(item.CurrentState, item.DeliveryOpt)));
                return Ok(cmdList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// This function change the status of a customer command in the basket
        /// </summary>
        /// <param name="basketID">Basket of the user link to the command</param>
        /// <param name="state">State to apply</param>
        /// <returns>200 on success, 403 on fail</returns>
        [HttpPut("updateStatus")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CmdChangeStatus(int basketID, Basket.State state)
        {
            try
            {
                Basket? basket = await _db.Baskets!.FirstAsync(basket => basket.Id == basketID);
                basket.CurrentState = state;
                _db.Baskets!.Update(basket);
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Display the custom command formular
        /// </summary>
        /// <param name="craftsmanID">Id of the craftsman to link with the command</param>
        /// <returns>Custom command page on success, redirect to AccountController::Login if not logged in or BadRequest</returns>
        [HttpGet("createCustomCmd/{craftsmanID}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateCustomCmd(string craftsmanID)
        {
            try
            {
                return Ok(await _db.Accounts!.SingleAsync(account => account.Id == craftsmanID));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Creates a custom command for the user
        /// </summary>
        /// <param name="cmd">Model containing craftsman id and command info</param>
        /// <returns>Redirect to ChatController::Chat on success, AccountController::Login if not logged in or BadRequest</returns>
        [HttpPost("createCustomCmd")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Redirect)]
        public async Task<IActionResult> PostCreateCustomCmd(CreateCustomCmdViewModel cmd)
        {
            try
            {
                Account account = await _utils.GetFromCookie(Request, _db);

                Account craftsman = await _db.Accounts!.SingleAsync(account => account.Id == cmd.CraftsmanID);
                if (craftsman == null)
                    throw new Exception("Artisan introuvable, id: " + craftsman);
                Product product = new(cmd.Name, craftsman, description: cmd.Desc, quantity: cmd.Quantity, images: new List<string> { "/img/Product/default.png" });
                var result = await _db.Products!.AddAsync(product);
                Basket basket = new(account, result.Entity, cmd.Quantity, DeliveryOption.DELIVERY, State.WAITINGCRAFTSMAN,
                    Enum.GetValues(typeof(State)).Cast<State>().ToList());
                await _db.Products!.AddAsync(product);
                await _db.Baskets!.AddAsync(basket);
                await _db.SaveChangesAsync();
                return Ok(new { product, basket });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Display custom command update formular
        /// </summary>
        /// <param name="basketID">BasketId of the command to update</param>
        /// <returns>Update command page on success, redirect AccountController::Login if not logged in or BadRequest</returns>
        [HttpGet("updateCustomCmd/{basketID}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCustomCmd(int basketID)
        {
            try
            {
                string? token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);
                var username = jwt.Claims.First(claim => claim.Type == "sub").Value;
                var user = _db.Accounts!.Single(u => u.UserName == username);
                Basket basket = await _db.Baskets!.Include("Product.Craftsman").SingleAsync(basket => basket.Id == basketID);
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
        /// <param name="cmd">Updated fields for command update</param>
        /// <returns>Redirect to ChatController::Chat on success, AccountController::Login if not logged in or BadRequest</returns>
        [HttpPut("basket/updateCustomCmd")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Redirect)]
        public async Task<IActionResult> PostUpdateCustomCmd(Basket cmd)
        {
            try
            {
                cmd.CurrentState = State.WAITINGCONSUMER;
                cmd.Product!.Quantity = cmd.Quantity;
                _db.Products!.Update(cmd.Product!);
                await _db.SaveChangesAsync();
                return RedirectToAction("Chat", "Chat", "toUserId=" + cmd.Account);
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
        #endregion
    }
}
