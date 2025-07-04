using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

[Route("api/[controller]/[action]")]
[ApiController]
public class MasterClassesController : ControllerBase
{
    private readonly SchoolManagementSystemContext _context;
    public MasterClassesController(SchoolManagementSystemContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MasterClass>>> GetMasterClasses() => Ok(await _context.MasterClasses.ToListAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<MasterClass>> GetMasterClassById(int id)
    {
        var item = await _context.MasterClasses.FindAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<MasterClass>> CreateMasterClass(MasterClass item)
    {
        await _context.MasterClasses.AddAsync(item);
        await _context.SaveChangesAsync();
        return Ok(item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMasterClass(int id, MasterClass item)
    {
        if (id != item.MasterClassId) return BadRequest();
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMasterClass(int id)
    {
        var item = await _context.MasterClasses.FindAsync(id);
        if (item == null) return NotFound();
        _context.MasterClasses.Remove(item);
        await _context.SaveChangesAsync();
        return Ok(id);
    }
}