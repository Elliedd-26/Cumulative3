namespace MySchoolAPI.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherFname { get; set; } = string.Empty;
        public string TeacherLname { get; set; } = string.Empty;
        public string EmployeeNumber { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
    }
}
