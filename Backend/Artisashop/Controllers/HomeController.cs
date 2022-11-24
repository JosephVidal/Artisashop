using System.Net;
using Artisashop.Models;
using Artisashop.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Artisashop.Controllers
{
    /// <summary>
    /// Handles home page display
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/home")]
    [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        private readonly StoreDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Account> _userManager;

        public HomeController(StoreDbContext db, RoleManager<IdentityRole> roleManager,
            UserManager<Account> userManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Displays home page with stats, random craftsman and product
        /// </summary>
        /// <returns>Home page with data or BadRequest</returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Home), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Index()
        {
            try
            {
                var sellerRole = _db.Roles.FirstOrDefault(x => x.Name == Roles.Seller);

                // var craftsmen = from c in _db.Users
                //     join role in _db.UserRoles on c.Id equals role.UserId
                //     where role.RoleId == sellerRole.Id
                //     select c;
                // // join u in _db.Users on c.UserId equals u.Id
                // // where u.Roles.Any(r => r.RoleId == sellerRole.Id)
                // // select c;

                var sellers = await _userManager.GetUsersInRoleAsync(Roles.Seller);
                int sellerCount = sellers.Count;
                var users = await _userManager.GetUsersInRoleAsync(Roles.User);
                int userCount = users.Count;
                List<Product> items = _db.Products!.Include(item => item.Craftsman).ToList();
                int productCount = items.Count;
                int sales = _db.Bills!.Count();

                Home viewModel = new Home()
                {
                    CraftsmanNumber = sellerCount,
                    ProductNumber = productCount,
                    CraftsmanSample = SelectRandom(sellers, 5),
                    ProductSample = SelectRandom(items, 5),
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
        /// This function randomize a list
        /// </summary>
        /// <typeparam name="T">Type of item to randomize</typeparam>
        /// <param name="list">List of element to randomize</param>
        /// <param name="number">Number of element to have in the list</param>
        /// <returns>List of randomized element</returns>
        private static List<T> SelectRandom<T>(IList<T> list, int number)
        {
            return list.OrderBy(x => Guid.NewGuid()).Take(number).ToList();
        }
    }
}