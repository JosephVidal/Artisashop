namespace Artisashop.Controllers;

using Artisashop.Common;
using Artisashop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/admin/product")]
public class AdminProductController : ReactAdminController<Product>
{
    public AdminProductController(StoreDbContext context) : base(context)
    {
        _table = _context.Products;
    }
}