﻿namespace Artisashop.Controllers;

using Artisashop.Common;
using Artisashop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/admin/userRole")]
[Authorize(Roles = Roles.Admin)]
public class AdminUserRoleController : ReactAdminController<IdentityUserRole<string>>
{
    public AdminUserRoleController(StoreDbContext context) : base(context)
    {
        _table = _context.UserRoles;
    }
}