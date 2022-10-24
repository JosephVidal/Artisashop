using Backend.Models;
using Backend.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Backend.Controllers
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

        public HomeController(StoreDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Displays home page with stats, random craftsman and product
        /// </summary>
        /// <returns>Home page with data or BadRequest</returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Home), (int)HttpStatusCode.OK)]
        public IActionResult Index()
        {
            try
            {
                List<Account> users = _db.Accounts!.Where(user => user.Role == Account.UserType.CRAFTSMAN).ToList();
                int userCount = users.Count;
                List<Product> items = _db.Products!.Include(item => item.Craftsman).ToList();
                int productCount = items.Count;
                Home viewModel = new Home()
                {
                    CraftsmanNumber = userCount,
                    ProductNumber = productCount,
                    CraftsmanSample = SelectRandom(users, 5),
                    ProductSample = SelectRandom(items, 5),
                    Inscrit = _db.Accounts!.Count(user => user.Role == Account.UserType.CONSUMER || user.Role == Account.UserType.CRAFTSMAN)
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
        private static List<T> SelectRandom<T>(List<T> list, int number)
        {
            return list.OrderBy(x => Guid.NewGuid()).Take(number).ToList();
        }
    }
}
