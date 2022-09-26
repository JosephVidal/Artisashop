using Artichaut.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Artichaut.Controllers
{
    /// <summary>
    /// Handles craftsman product list
    /// </summary>
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/craftsman")]
    public class CraftsmanController : ControllerBase
    {
        public readonly StoreDbContext _db;

        public CraftsmanController(StoreDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Displays craftsman product list
        /// </summary>
        /// <param name="userId">Craftsman to display id</param>
        /// <returns>Craftsman Index page, NotFound or BadRequest</returns>
        [HttpGet("craftsman/{userId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Index(string userId)
        {
            try
            {
                Account? craftsman = await _db.Accounts!.Include("Items").FirstOrDefaultAsync(user => user.Id == userId);

                if (craftsman == null)
                    return NotFound();
                return Ok(craftsman);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
