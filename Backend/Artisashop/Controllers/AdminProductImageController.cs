namespace Artisashop.Controllers;

using Artisashop.Common;
using Artisashop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/admin/productImage")]
[Authorize(Roles = Roles.Admin)]
public class AdminProductImageController : ReactAdminController<ProductImage>
{
    public AdminProductImageController(StoreDbContext context) : base(context)
    {
        _table = _context.ProductImages;
    }
}