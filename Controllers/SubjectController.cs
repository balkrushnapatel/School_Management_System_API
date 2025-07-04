using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

[ApiController]
[Route("api/[controller]/[action]")]
public class SubjectsController : ControllerBase
{
    private readonly SchoolManagementSystemContext _context;

    public SubjectsController(SchoolManagementSystemContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Subject>>> GetSubjectDetails()
    {
        return Ok(await _context.Subjects.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Subject>> GetSubjectById(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);
        if (subject == null) return NotFound();
        return Ok(subject);
    }

    [HttpPost]
    public async Task<ActionResult<Subject>> CreateSubject(Subject subject)
    {
        await _context.Subjects.AddAsync(subject);
        await _context.SaveChangesAsync();
        return Ok(subject);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Subject>> UpdateSubject(int id, Subject subject)
    {
        if (id != subject.SubjectId) return BadRequest();
        _context.Entry(subject).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(subject);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSubject(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);
        if (subject == null) return NotFound();
        _context.Subjects.Remove(subject);
        await _context.SaveChangesAsync();
        return Ok(id);
    }
}
