using Microsoft.AspNetCore.Mvc;
using Attendance_System.Models;  
using System.Collections.Generic;
using System.Linq;
using Attendance_System.Data;

namespace Attendance_System.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public IActionResult Index()
        {
            List<Employee> employees = _context.Employees.ToList();
            return View(employees);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }
    }
}
