using Artisashop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Artisashop.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ComplaintController : ControllerBase
{
    private readonly StoreDbContext _storeDbContext;

    public ComplaintController(StoreDbContext storeDbContext)
    {
        _storeDbContext = storeDbContext;
    }


    [HttpPost, Route("[controller]", Name = "CreateComplaint")]
    public async Task<Complaint> Post(Complaint complaint)
    {
        var elem = await _storeDbContext.Complaints.AddAsync(complaint);
        await _storeDbContext.SaveChangesAsync();
        return elem.Entity;
    }

    [HttpGet, Route("[controller]", Name = "GetAllComplaints")]
    public async Task<IEnumerable<Complaint>> Get(string? userId = null, int? productId = null)
    {
        IQueryable<Complaint> query = _storeDbContext.Complaints;
        if (userId != null) {
            query = query.Where(x => x.UserId == userId);
        }
        if (productId != null) {
            query = query.Where(x => x.ProductId == productId);
        }
        return await query.ToListAsync();
    }

    [HttpGet, Route("[controller]/{id}", Name = "GetComplaint")]
    public async Task<Complaint?> Get(int id)
    {
        return await _storeDbContext.Complaints.FirstOrDefaultAsync(x => x.Id == id);
    }
}