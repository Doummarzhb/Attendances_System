using Attendance_System.Data;
using Attendance_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Attendance_System.Controllers
{

    public class AttendanceController : Controller
    {
        private readonly AppDbContext _context;

        public AttendanceController(AppDbContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            var attendanceList = await _context.Attendances
                .Include(a => a.Employee)
                .ToListAsync();

            return View(attendanceList);
        }

        // Check In
        [HttpPost]
        public async Task<IActionResult> CheckIn(int employeeId)
        {
            var today = DateTime.Today;

          
            var existingAttendance = await _context.Attendances
                .FirstOrDefaultAsync(a => a.EmployeeId == employeeId && a.Date == today);

            if (existingAttendance != null)
            {
          
                return RedirectToAction("Index");
            }

            var now = DateTime.Now;

            var attendance = new Attendance
            {
                EmployeeId = employeeId,
                CheckIn = now,
                Date = now.Date,
                Status = now.Hour > 9 ? "Late" : "On Time"
            };

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // Check Out
        [HttpPost]
        public async Task<IActionResult> CheckOut(int attendanceId)
        {
            var attendance = await _context.Attendances.FindAsync(attendanceId);

            if (attendance == null)
            {
                return NotFound();
            }

            if (attendance.CheckOut == null)
            {
                attendance.CheckOut = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
