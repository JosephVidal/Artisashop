namespace Artisashop.Controllers;

using System;
using Artisashop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
[ApiController]
[Route("api/reports")]
public class ReportController : ControllerBase
{
    private readonly StoreDbContext _context;

    public ReportController(StoreDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Report), StatusCodes.Status200OK)]
    public async Task<ActionResult<Report>> GetReport(int id)
    {
        return Ok(await _context.Reports.FindAsync(id));
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Report>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Report>>> GetReports()
    {
        return Ok(await _context.Reports.ToListAsync());
    }

    [HttpPost]
    [ProducesResponseType(typeof(Report), StatusCodes.Status201Created)]
    public async Task<ActionResult> PostReport(Report report)
    {
        _context.Reports.Add(report);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetReport), new { id = report.Id }, report);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> PutReport(int id, Report report)
    {
        if (id != report.Id)
            return BadRequest();
        _context.Entry(report).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReportExists(id))
                return NotFound();
            throw;
        }
        return NoContent();
    }

    [HttpPost("{id}/resolve")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> ResolveReport(int id)
    {
        Report? report = await _context.Reports.FindAsync(id);
        if (report == null)
            return NotFound();
        report.Status = ReportStatus.Accepted;
        _context.Entry(report).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteReport(int id)
    {
        var report = await _context.Reports.FindAsync(id);
        if (report == null)
            return NotFound();
        _context.Reports.Remove(report);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool ReportExists(int id)
    {
        return _context.Reports.Any(e => e.Id == id);
    }
}