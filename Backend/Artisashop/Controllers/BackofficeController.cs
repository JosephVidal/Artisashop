using System.Net;
using Artisashop.Interfaces.IService;
using Artisashop.Models;
using Artisashop.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Artisashop.Controllers
{
    /// <summary>
    /// This controller displays the admin interface
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/backoffice/")]
    [Authorize(Roles = Roles.Admin)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.Unauthorized)]
    public class BackofficeController : ControllerBase
    {
        private readonly IMailService _mailService;
        private readonly StoreDbContext _db;
        private readonly UserManager<Account> _userManager;

        public BackofficeController(IMailService mailService, StoreDbContext db, UserManager<Account> userManager)
        {
            _mailService = mailService;
            _db = db;
            _userManager = userManager;
        }

        /// <summary>
        /// This function display the backoffice main page
        /// </summary>
        /// <returns>Index page if user is amdin, Unauthorized if not admin, redirect to AccountController::Login if not logged in or BadRequest</returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<Account>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _userManager.GetUsersInRoleAsync(Roles.Seller);
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Displays the validation page
        /// </summary>
        /// <returns>The stat page on success, Unauthorized if not admin, redirect to AccountController::Login or BadRequest</returns>
        [HttpGet("stats")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Home), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Stats()
        {
            try
            {
                var sellerCount = _userManager.GetUsersInRoleAsync(Roles.Seller).Result.Count;
                var productCount = _db.Products.Count();
                var userCount = _userManager.GetUsersInRoleAsync(Roles.User).Result.Count;
                int sales = _db.Bills.Count();

                Home viewModel = new Home()
                {
                    CraftsmanNumber = sellerCount,
                    ProductNumber = productCount,
                    Inscrit = userCount,
                    Sales = sales
                };

                return Ok(viewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// This function change the validation status
        /// </summary>
        /// <param name="username">The user id of the account to delete as string</param>
        /// <param name="validationStatus">The changed value</param>
        /// <returns>Success JsonResult or error message</returns>
        [HttpPatch("changeValidationStatus")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ChangeCraftsmanValidationStatus([FromBody] Dictionary<string, string> model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model["username"]);

                if (user == null)
                    return NotFound("Account with username " + model["username"] + " not found");
                if (bool.Parse(model["validationStatus"]) == true)
                    _mailService.SendMail(user.Email, "Artisashop - Validation de compte", "");
                return Ok("Validation status for " + model["username"] + " : " + user.EmailConfirmed);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// This changes a boolean parameter
        /// </summary>
        /// <param name="userId">Id of the user to update</param>
        /// <param name="propertyName">The parameter to change in the account</param>
        /// <param name="value">True or false</param>
        /// <returns></returns>
        [HttpPatch("setAccountParam")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SetAccountParam(string userId, string propertyName, bool value)
        {
            try
            {
                Account user = await _userManager.FindByIdAsync(userId);
                var propety = user.GetType().GetProperty(propertyName);
                if (propety != null) {
                    propety.SetValue(user, value);
                    _db.Update(user);
                    _db.SaveChanges();

                    return Ok("Property " + propertyName + " set with value " + value);
                } else
                {
                    return NotFound("Property " + propertyName + " not found");
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
