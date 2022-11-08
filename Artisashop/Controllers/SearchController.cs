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
                    query = query.Where(item => item.Craftsman != null && item.Craftsman.Job == search.Job);
                if (search.Styles != null)
                    foreach (string style in search.Styles)
                        query = query.Where(item => item.StylesList != null && item.StylesList.Contains(style));
                if (search.UserGPSCoord != null && search.Distance != null && search.Distance != 0)
                    query = query.Where(item => item.Craftsman != null && item.Craftsman.AddressGPS != null && Haversine(search.UserGPSCoord, item.Craftsman.AddressGPS) <= search.Distance);
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
                if (search.Job != null && search.Job != "")
                    query = query.Where(item => item!.Job == search.Job);
                if (search.UserGPSCoord != null && search.Distance != null && search.Distance != 0)
                    query = query.Where(item => item.AddressGPS != null && Haversine(search.UserGPSCoord, item.AddressGPS) <= search.Distance);
                return Ok(await query.ToListAsync());
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
            double A = Math.Pow(Math.Sin(deltaPhi / 2), 2) + (Math.Cos(phiA) * Math.Cos(phiB) * Math.Pow(Math.Sin(deltaLambda), 2));
            double C = 2 * Math.Atan2(Math.Sqrt(A), Math.Sqrt(1 - A));
            double D = radius * C;
            return D;
        }

    }
}