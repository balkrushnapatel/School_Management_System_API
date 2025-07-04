using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

[Route("api/[controller]/[action]")]
[ApiController]
public class TrustController : ControllerBase
{
    private readonly SchoolManagementSystemContext _context;

    public TrustController(SchoolManagementSystemContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Trust>>> GetTrusts()
    {
        return Ok(await _context.Trusts.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Trust>> GetTrustById(int id)
    {
        var trust = await _context.Trusts.FindAsync(id);
        if (trust == null) return NotFound();
        return Ok(trust);
    }

    [HttpPost]
    public async Task<ActionResult<Trust>> CreateTrust(Trust trust)
    {
        await _context.Trusts.AddAsync(trust);
        await _context.SaveChangesAsync();
        return Ok(trust);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Trust>> UpdateTrust(int id, Trust trust)
    {
        if (id != trust.TrustId) return BadRequest();
        _context.Entry(trust).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(trust);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTrust(int id)
    {
        var trust = await _context.Trusts.FindAsync(id);
        if (trust == null) return NotFound();
        _context.Trusts.Remove(trust);
        await _context.SaveChangesAsync();
        return Ok(id);
    }
}
