using System.Net;
using Artisashop.Interfaces.IService;
using Artisashop.Models;
using Artisashop.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Artisashop.Models.Account;

namespace Artisashop.Controllers
{
    /// <summary>
    /// This controller displays the admin interface
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/backoffice")]
    [Authorize(Roles = "ADMIN")]
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
                var users = _userManager.GetUsersInRoleAsync(Roles.Seller);
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

                Home viewModel = new Home()
                {
                    CraftsmanNumber = sellerCount,
                    ProductNumber = productCount,
                    Inscrit = userCount,
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
    }
}
