namespace University_Management_System.Models.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int CourseCost { get; set; }
        public int InstructorCourse { get; set; }
        public virtual Instructor? Instructor { get; set; }
        public int CourseDepartment { get; set; }
        public virtual Department? Department { get; set; }
        public virtual List<StudentCourse>? StudentCourses { get; set; }
    }
}