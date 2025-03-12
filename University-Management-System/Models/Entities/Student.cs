namespace University_Management_System.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int StudentDepartment { get; set; }
        public virtual Department? Department { get; set; }
        public int StudentFaculty { get; set; }
        public virtual Faculty? Faculty { get; set; }
        public virtual List<StudentCourse>? StudentCourses { get; set; }
    }
}
