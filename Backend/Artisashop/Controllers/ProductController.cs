using System.Net;
using System.Text.Json;
using Artisashop.Models;
using Artisashop.Models.ViewModel;
using Artisashop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Artisashop.Controllers
{
    /// <summary>
    /// Handles product display and interactions
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(Roles = Roles.Seller)]
    public class ProductController : ControllerBase
    {
        private readonly StoreDbContext _db;
        private readonly Utils _utils = new();

        public ProductController(StoreDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Displays a craftsman product list
        /// </summary>
        /// <returns>Product Index page on success, Unauthorized if not craftsmann, AccountController::Login if not logged in or BadRequest</returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<Product>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ProductList(string? sellerId = null)
        {
            try
            {
                IQueryable<Product> query = _db.Products
                    .Include(x => x.ProductStyles)
                    .Include(x => x.ProductImages)
                    ;
                if (sellerId != null)
                {
                    query = query.Where(p => p.CraftsmanId == sellerId);
                }
                List<Product> products = await query.ToListAsync();
                if (!products.Any())
                    return NotFound("Didn't find any products");
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Displays product infos
        /// </summary>
        /// <param name="productId">The id of the product to display</param>
        /// <returns>Product page on success, or BadRequest</returns>
        [HttpGet("info/{productId}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Product(int productId)
        {
            try
            {
                Product product = await _db.Products
                    .Include(p => p.ProductStyles)
                    .Include(p => p.ProductImages)
                    .Include(p => p.Craftsman)
                    .FirstAsync(product => product.Id == productId);
                if (product == null)
                    return NotFound("Product with id " + productId + " not found");
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="model">Model containing new product information</param>
        /// <returns>Update page on success, Unauthorized if not craftsman, AccountController::Login if not logged in or BadRequest</returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] CreateProduct model)
        {
            try
            {
                Account account = await _utils.GetFromCookie(Request, _db);
                Product product =
                    new Product
                    {
                        Craftsman = account,
                        CraftsmanId = account.Id,
                        Name = model.Name,
                        Description = model.Description,
                        Price = model.Price,
                        Quantity = model.Quantity,
                        ProductImages = model.Images.Select(i => new ProductImage { Content = i }).ToList(),
                        ProductStyles = model.Styles.Select(name => new ProductStyle(name)).ToList(),
                    };
                    // new(model, account);

                var success = await _db.Products!.AddAsync(product);
                if (success == null)
                    return BadRequest("Creation failed");
                await _db.SaveChangesAsync();
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="productId">The id of the product to update</param>
        /// <returns>Update page on success, NotFound, Unauthorized if not craftsman, AccountController::Login if not logged in or BadRequest</returns>
        [HttpPatch("update/{productId}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int productId, [FromBody] CreateProduct model)
        {
            try
            {
                Product? product = await _db.Products!.FirstOrDefaultAsync(product => product.Id == productId);
                if (product == null)
                    return NotFound("Product with id " + productId + " not found");
                _utils.UpdateObject(product, model);
                product.ProductImages = model.Images.Select(x => new ProductImage() { Content = x }).ToList();
                product.ProductStyles = model.Styles.Select(x => new ProductStyle(x)).ToList();
                var success = _db.Products!.Update(product);
                if (success == null)
                    return BadRequest("Update failed");
                await _db.SaveChangesAsync();
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deletes a product from the list
        /// </summary>
        /// <param name="productId">The id of the product to delete</param>
        /// <returns>Index page on success, Unauthorized if not craftsman, AccountController::Login if not logged in ot BadRequest</returns>
        [HttpDelete("delete/{productId}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int productId)
        {
            try
            {
                Product? product = await _db.Products!.FirstOrDefaultAsync(product => product.Id == productId);
                if (product == null)
                    return NotFound("Product with id " + productId + " not found");
                var success = _db.Products!.Remove(product);
                if (success == null)
                    return BadRequest("Deletion failed");
                await _db.SaveChangesAsync();
                return Ok("Product with id " + productId + " deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}