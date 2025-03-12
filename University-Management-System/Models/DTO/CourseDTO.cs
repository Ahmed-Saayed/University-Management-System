namespace University_Management_System.Models.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int CourseCost { get; set; }
        public int InstructorCourse { get; set; }
        public int CourseDepartment { get; set; }
    }
}
