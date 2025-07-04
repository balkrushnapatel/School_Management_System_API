using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

[Route("api/[controller]/[action]")]
[ApiController]
public class AttendanceController : ControllerBase
{
    private readonly SchoolManagementSystemContext _context;

    public AttendanceController(SchoolManagementSystemContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Attendance>>> GetAllAttendance()
    {
        var attendanceList = await _context.Attendances.ToListAsync();
        return Ok(attendanceList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Attendance>> GetAttendanceById(int id)
    {
        var attendance = await _context.Attendances.FindAsync(id);
        if (attendance == null) return NotFound();
        return Ok(attendance);
    }

    [HttpPost]
    public async Task<ActionResult<Attendance>> MarkAttendance([FromBody] Attendance attendance)
    {
        await _context.Attendances.AddAsync(attendance);
        await _context.SaveChangesAsync();
        return Ok(attendance);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAttendance(int id, [FromBody] Attendance attendance)
    {
        if (id != attendance.AttendanceId) return BadRequest();
        _context.Entry(attendance).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(attendance);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAttendance(int id)
    {
        var attendance = await _context.Attendances.FindAsync(id);
        if (attendance == null) return NotFound();
        _context.Attendances.Remove(attendance);
        await _context.SaveChangesAsync();
        return Ok(id);
    }
}
