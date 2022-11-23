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
    /// Handles every search actions
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/search/")]
    [AllowAnonymous]
    public class SearchController : ControllerBase
    {
        private readonly StoreDbContext _db;
        private readonly UserManager<Account> _userManager;

        public SearchController(StoreDbContext db, UserManager<Account> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet("product")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<Product>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ProductSearch([FromQuery] ProductSearch search)
        {
            try
            {
                IQueryable<Product> query = _db.Products
                    .Include(item => item.Craftsman)
                    .Include(item => item.Craftsman!.AddressGPS)
                    .Include(item => item.ProductImages)
                    .Include(item => item.ProductStyles);
                if (!string.IsNullOrEmpty(search.Name))
                    query = query.Where(item => item.Name.Contains(search.Name, StringComparison.OrdinalIgnoreCase));
                if (!string.IsNullOrEmpty(search.Job))
                    query = query.Where(item => item.Craftsman != null && item.Craftsman.Job == search.Job);
                if (search.Styles != null)
                    foreach (string searchStyle in search.Styles.Select(ProductStyle.GetNormalizedName))
                        query = query.Where(item =>
                            item.ProductStyles != null && item.ProductStyles.Any(x => x.NormalizedName == searchStyle));
                var res = await query.ToListAsync();
                if (search.UserGPSCoord != null && search.Distance != null && search.Distance != 0)
                    res = res.Where(item =>
                        item.Craftsman != null && item.Craftsman.AddressGPS != null &&
                        Haversine(search.UserGPSCoord, item.Craftsman.AddressGPS) <= search.Distance).ToList();
                return Ok(res);
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
            var sellerRole = _db.Roles.FirstOrDefault(x => x.Name == Roles.Seller);

            try
            {
                IQueryable<Account> query = _db.Users
                    .Join(_db.UserRoles,
                        user => user.Id,
                        userRole => userRole.UserId,
                        (user, userRole) => new { user, userRole }).Where(x => x.userRole.RoleId == sellerRole.Id)
                    .Select(x => x.user).AsQueryable().Include(item => item.AddressGPS);
                if (search.FirstName != null && search.FirstName != "")
                    query = query.Where(item => item.Firstname == search.FirstName);
                if (search.LastName != null && search.LastName != "")
                    query = query.Where(item => item.Lastname == search.LastName);
                if (search.Job != null && search.Job != "")
                    query = query.Where(item => item!.Job == search.Job);
                var res = await query.ToListAsync();
                if (search.UserGPSCoord != null && search.Distance != null && search.Distance != 0)
                    res = res.Where(item =>
                        item.AddressGPS != null && Haversine(search.UserGPSCoord, item.AddressGPS) <= search.Distance).ToList();
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private double Haversine(GPSCoord a, GPSCoord b)
        {
            return Haversine(a, b, 6371000); // Call Haversine Formula W/ the earth radius in meter
        }

        private double Haversine(GPSCoord a, GPSCoord b, double radius)
        {
            double radFact = Math.PI / 180;
            double phiA = radFact * a.Latitude;
            double phiB = radFact * b.Latitude;
            double deltaPhi = radFact * (b.Latitude - a.Latitude);
            double deltaLambda = radFact * (a.Longitude - b.Longitude);
            double A = Math.Pow(Math.Sin(deltaPhi / 2), 2) +
                       (Math.Cos(phiA) * Math.Cos(phiB) * Math.Pow(Math.Sin(deltaLambda), 2));
            double C = 2 * Math.Atan2(Math.Sqrt(A), Math.Sqrt(1 - A));
            double D = radius * C;
            return D;
        }
    }
}