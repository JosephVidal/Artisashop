namespace Artisashop.Controllers;

using Artisashop.Common;
using Artisashop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/admin/role")]
[Authorize(Roles = Roles.Admin)]
public class AdminRoleController : ReactAdminController<IdentityRole>
{
    public AdminRoleController(StoreDbContext context) : base(context)
    {
        _table = _context.Roles;
    }
}