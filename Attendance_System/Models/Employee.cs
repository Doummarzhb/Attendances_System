namespace Attendance_System.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}
