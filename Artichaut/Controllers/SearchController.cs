using Artichaut.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Artichaut.Controllers
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

        [HttpPost("product")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> ProductSearch(List<string> styleSelect, string? name = null, string? job = null)
        {
            try
            {
                IQueryable<Product> query = _db.Products!.Include(item => item.Craftsman).AsQueryable();
                if (name != null && name != "")
                    query = query.Where(item => item.Name == name);
                if (job != null && job != "")
                    query = query.Where(item => item.Craftsman!.Job == job);
                foreach (string style in styleSelect)
                    query = query.Where(item => item.StyleList!.Contains(style));
                return Ok(await query.ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("craftsman")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CraftsmanSearch(string? firstName = null, string? lastName = null, string? job = null)
        {
            try
            {
                IQueryable<Account> query = _db.Accounts!.Where(account => account.Role == Account.UserType.CRAFTSMAN).AsQueryable();
                if (firstName != null && firstName != "")
                    query = query.Where(item => item.Firstname == firstName);
                if (lastName != null && lastName != "")
                    query = query.Where(item => item.Lastname == lastName);
                if (job != null && job != "")
                    query = query.Where(item => item!.Job == job);
                return Ok(await query.ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}