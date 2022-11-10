using System.Net;
using Artisashop.Models;
using Artisashop.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Artisashop.Controllers
{
    /// <summary>
    /// Handles every search actions
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/search/")]
    [AllowAnonymous]
    public class SearchController : ControllerBase
    {
        private readonly StoreDbContext _db;

        public SearchController(StoreDbContext db)
        {
            _db = db;
        }

        [HttpGet("product")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<Product>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ProductSearch([FromQuery] ProductSearch search)
        {
            try
            {
                IQueryable<Product> query = _db.Products!.Include(item => item.Craftsman).AsQueryable();
                if (search.Name != null && search.Name != "")
                    query = query.Where(item => item.Name == search.Name);
                if (search.Job != null && search.Job != "")
                    query = query.Where(item => item.Craftsman!.Job == search.Job);
                if (search.Styles != null)
                    foreach (string style in search.Styles)
                        query = query.Where(item => item.StylesList!.Contains(style));
                return Ok(await query.ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("craftsman")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<Account>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CraftsmanSearch([FromQuery] CraftsmanSearch search)
        {
            try
            {
                IQueryable<Account> query = _db.Accounts!.Where(account => account.Role == Account.UserType.CRAFTSMAN).AsQueryable();
                if (search.FirstName != null && search.FirstName != "")
                    query = query.Where(item => item.Firstname == search.FirstName);
                if (search.LastName != null && search.LastName != "")
                    query = query.Where(item => item.Lastname == search.LastName);
                if (search.FirstName != null && search.FirstName != "")
                    query = query.Where(item => item!.Job == search.Job);
                return Ok(await query.ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}