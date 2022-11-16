﻿using Artisashop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Artisashop.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ComplaintController : ControllerBase
{
    private readonly StoreDbContext _storeDbContext;

    public ComplaintController(StoreDbContext storeDbContext)
    {
        _storeDbContext = storeDbContext;
    }


    [HttpPost]
    public async Task<Complaint> Post(Complaint complaint)
    {
        var elem = await _storeDbContext.Complaints.AddAsync(complaint);
        await _storeDbContext.SaveChangesAsync();
        return elem.Entity;
    }

    [HttpGet]
    public async Task<IEnumerable<Complaint>> Get()
    {
        return await _storeDbContext.Complaints.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<Complaint?> Get(int id)
    {
        return await _storeDbContext.Complaints.FirstOrDefaultAsync(x => x.Id == id);
    }
}