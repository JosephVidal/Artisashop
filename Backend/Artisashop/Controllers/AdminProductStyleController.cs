namespace Artisashop.Controllers;

using Artisashop.Common;
using Artisashop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/admin/productStyle")]
public class AdminProductStyleController : ReactAdminController<ProductStyle>
{
    public AdminProductStyleController(StoreDbContext context) : base(context)
    {
        _table = _context.ProductStyles;
    }
}