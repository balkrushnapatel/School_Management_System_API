using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

[Route("api/[controller]/[action]")]
[ApiController]
public class FacultySubjectsController : ControllerBase
{
    private readonly SchoolManagementSystemContext _context;
    public FacultySubjectsController(SchoolManagementSystemContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FacultySubject>>> GetFacultySubjects() => Ok(await _context.FacultySubjects.ToListAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<FacultySubject>> GetFacultySubjectById(int id)
    {
        var item = await _context.FacultySubjects.FindAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<FacultySubject>> CreateFacultySubject(FacultySubject item)
    {
        await _context.FacultySubjects.AddAsync(item);
        await _context.SaveChangesAsync();
        return Ok(item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFacultySubject(int id, FacultySubject item)
    {
        if (id != item.FacultySubjectId) return BadRequest();
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFacultySubject(int id)
    {
        var item = await _context.FacultySubjects.FindAsync(id);
        if (item == null) return NotFound();
        _context.FacultySubjects.Remove(item);
        await _context.SaveChangesAsync();
        return Ok(id);
    }
}