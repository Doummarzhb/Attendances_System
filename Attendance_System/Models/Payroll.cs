namespace Attendance_System.Models
{
    public class Payroll
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal SalaryPerDay { get; set; }
        public int TotalDaysPresent { get; set; }
        public decimal TotalSalary { get; set; }
        public DateTime PaymentDate { get; set; }

        public Employee Employee { get; set; }
    }
}
