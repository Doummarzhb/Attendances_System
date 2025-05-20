using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_System.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        public string? Status { get; set; } // Optional: "Present", "Late", etc.

        [NotMapped]
        public TimeSpan? Duration
        {
            get
            {
                if (CheckOut.HasValue)
                    return CheckOut.Value - CheckIn;
                return null;
            }
        }

        public Employee Employee { get; set; }
    }
}

