using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly SchoolManagementSystemContext _context;

        public StaffController(SchoolManagementSystemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Staff>>> GetStaffDetails()
        {
            return Ok(await _context.Staff.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaffById(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
                return NotFound();
            return Ok(staff);
        }

        [HttpPost]
        public async Task<ActionResult<Staff>> CreateStaff(Staff staff)
        {
            await _context.Staff.AddAsync(staff);
            await _context.SaveChangesAsync();
            return Ok(staff);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Staff>> UpdateStaff(int id, Staff staff)
        {
            if (id != staff.StaffId) return BadRequest();
            _context.Entry(staff).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(staff);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStaff(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (staff == null) return NotFound();
            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
            return Ok(id);
        }
    }
}
