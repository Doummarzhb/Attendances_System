using Attendance_System.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Attendance_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Payroll> Payrolls { get; set; }
    }
}
