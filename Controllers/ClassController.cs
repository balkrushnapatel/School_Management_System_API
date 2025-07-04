using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

[ApiController]
[Route("api/[controller]/[action]")]
public class ClassesController : ControllerBase
{
    private readonly SchoolManagementSystemContext _context;

    public ClassesController(SchoolManagementSystemContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Class>>> GetClassDetails()
    {
        return Ok(await _context.Classes.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Class>> GetClassById(int id)
    {
        var cls = await _context.Classes.FindAsync(id);
        if (cls == null) return NotFound();
        return Ok(cls);
    }

    [HttpPost]
    public async Task<ActionResult<Class>> CreateClass(Class cls)
    {
        await _context.Classes.AddAsync(cls);
        await _context.SaveChangesAsync();
        return Ok(cls);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Class>> UpdateClass(int id, Class cls)
    {
        if (id != cls.ClassId) return BadRequest();
        _context.Entry(cls).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(cls);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteClass(int id)
    {
        var cls = await _context.Classes.FindAsync(id);
        if (cls == null) return NotFound();
        _context.Classes.Remove(cls);
        await _context.SaveChangesAsync();
        return Ok(id);
    }
}
