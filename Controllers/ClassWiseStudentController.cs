using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

[Route("api/[controller]/[action]")]
[ApiController]
public class ClassWiseStudentController : ControllerBase
{
    private readonly SchoolManagementSystemContext _context;
    public ClassWiseStudentController(SchoolManagementSystemContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClassWiseStudent>>> GetClassWiseStudents() => Ok(await _context.ClassWiseStudents.ToListAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<ClassWiseStudent>> GetClassWiseStudentById(int id)
    {
        var item = await _context.ClassWiseStudents.FindAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<ClassWiseStudent>> CreateClassWiseStudent(ClassWiseStudent item)
    {
        await _context.ClassWiseStudents.AddAsync(item);
        await _context.SaveChangesAsync();
        return Ok(item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClassWiseStudent(int id, ClassWiseStudent item)
    {
        if (id != item.ClassWiseStudentId) return BadRequest();
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClassWiseStudent(int id)
    {
        var item = await _context.ClassWiseStudents.FindAsync(id);
        if (item == null) return NotFound();
        _context.ClassWiseStudents.Remove(item);
        await _context.SaveChangesAsync();
        return Ok(id);
    }
}
