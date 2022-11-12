using Artisashop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Artisashop.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class SellerController : ControllerBase
{
    private readonly StoreDbContext _context;
    private readonly UserManager<Account> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SellerController(StoreDbContext context, UserManager<Account> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    
    // [HttpPost]
    // public async Task<ActionResult> CreateSeller([FromBody] Seller seller)
    // {
    //     var user = new Account
    //     {
    //         UserName = seller.Email,
    //         Email = seller.Email,
    //         FirstName = seller.FirstName,
    //         LastName = seller.LastName,
    //         PhoneNumber = seller.PhoneNumber
    //     };
    //     var result = await _userManager.CreateAsync(user, seller.Password);
    //     if (result.Succeeded)
    //     {
    //         await _userManager.AddToRoleAsync(user, "Seller");
    //         return Ok();
    //     }
    //     return BadRequest(result.Errors);
    // }
    
    [HttpGet]
    public async Task<ActionResult> GetSellers()
    {
        var sellers = await _context.Sellers.ToListAsync();
        return Ok(sellers);
    }
    
    [HttpGet("{userId}")]
    public async Task<ActionResult> GetSellerById(int userId)
    {
        var seller = await _context.Sellers.FindAsync(userId);
        return Ok(seller);
    }

    [HttpGet("{username}")]
    [ProducesResponseType(typeof(Seller), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetSellerByUsername(string username)
    {
        var user = _context.Users.FirstOrDefault(x => x.UserName == username);
        var isSeller = await _userManager.IsInRoleAsync(user, Roles.Seller);
        if (!isSeller)
        {
            return BadRequest("User is not a seller");
        }
        var seller = _context.Sellers.FirstOrDefault(x => x.AccountId == user.Id);
        return Ok(seller);
    }
    
    // [HttpPut("{userId}")]
    // public async Task<ActionResult> UpdateSeller(string userId, [FromBody] Seller seller)
    // {
    //     var user = _context.Users.FirstOrDefault(u => u.Id == userId);
    // }
    
    [HttpDelete("{userId}")]
    public async Task<ActionResult> DeleteSeller(string userId)
    {
        var seller = await _context.Sellers.FindAsync(userId);
        _context.Sellers.Remove(seller);
        await _context.SaveChangesAsync();
        return Ok();
    }
}