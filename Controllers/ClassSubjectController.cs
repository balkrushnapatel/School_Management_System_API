using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

[Route("api/[controller]/[action]")]
[ApiController]
public class ClassSubjectsController : ControllerBase
{
    private readonly SchoolManagementSystemContext _context;

    public ClassSubjectsController(SchoolManagementSystemContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClassSubject>>> GetAll()
    {
        return Ok(await _context.ClassSubjects.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClassSubject>> GetById(int id)
    {
        var entity = await _context.ClassSubjects.FindAsync(id);
        return entity == null ? NotFound() : Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<ClassSubject>> Create(ClassSubject obj)
    {
        await _context.ClassSubjects.AddAsync(obj);
        await _context.SaveChangesAsync();
        return Ok(obj);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, ClassSubject obj)
    {
        if (id != obj.ClassSubjectId) return BadRequest();
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(obj);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var entity = await _context.ClassSubjects.FindAsync(id);
        if (entity == null) return NotFound();
        _context.ClassSubjects.Remove(entity);
        await _context.SaveChangesAsync();
        return Ok(id);
    }
}