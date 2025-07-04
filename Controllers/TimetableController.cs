using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

[ApiController]
[Route("api/[controller]/[action]")]
public class TimetableController : ControllerBase
{
    private readonly SchoolManagementSystemContext _context;

    public TimetableController(SchoolManagementSystemContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Timetable>>> GetTimetableDetails()
    {
        return Ok(await _context.Timetables.ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult<Timetable>> CreateTimetable(Timetable timetable)
    {
        await _context.Timetables.AddAsync(timetable);
        await _context.SaveChangesAsync();
        return Ok(timetable);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Timetable>> UpdateTimetable(int id, Timetable timetable)
    {
        if (id != timetable.TimetableId) return BadRequest();
        _context.Entry(timetable).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(timetable);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTimetable(int id)
    {
        var timetable = await _context.Timetables.FindAsync(id);
        if (timetable == null) return NotFound();
        _context.Timetables.Remove(timetable);
        await _context.SaveChangesAsync();
        return Ok(id);
    }
}
