using Artisashop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Artisashop.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly StoreDbContext _context;

    public ProfileController(StoreDbContext context)
    {
        _context = context;
    }
    
    
}