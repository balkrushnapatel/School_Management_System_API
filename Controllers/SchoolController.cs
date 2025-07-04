using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

[Route("api/[controller]/[action]")]
[ApiController]
public class SchoolController : ControllerBase
{
    private readonly SchoolManagementSystemContext _context;

    public SchoolController(SchoolManagementSystemContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<School>>> GetSchools()
    {
        return Ok(await _context.Schools.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<School>> GetSchoolById(int id)
    {
        var school = await _context.Schools.FindAsync(id);
        if (school == null) return NotFound();
        return Ok(school);
    }

    [HttpPost]
    public async Task<ActionResult<School>> CreateSchool(School school)
    {
        await _context.Schools.AddAsync(school);
        await _context.SaveChangesAsync();
        return Ok(school);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<School>> UpdateSchool(int id, School school)
    {
        if (id != school.SchoolId) return BadRequest();
        _context.Entry(school).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(school);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSchool(int id)
    {
        var school = await _context.Schools.FindAsync(id);
        if (school == null) return NotFound();
        _context.Schools.Remove(school);
        await _context.SaveChangesAsync();
        return Ok(id);
    }
}
