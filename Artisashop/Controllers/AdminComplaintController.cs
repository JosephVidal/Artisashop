namespace Artisashop.Controllers;

using Artisashop.Common;
using Artisashop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/admin/complaint")]
public class AdminComplaintController : ReactAdminController<Complaint>
{
    public AdminComplaintController(StoreDbContext context) : base(context)
    {
        _table = _context.Complaints;
    }
}