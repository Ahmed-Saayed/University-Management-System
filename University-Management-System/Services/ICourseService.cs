using University_Management_System.Models.DTO;
using University_Management_System.Models.Entities;

namespace University_Management_System.Services
{
    public interface ICourseService
    {
        public Task<List<Course>> GetAll();
        public Course GetCourseById(int id);
        public Course AddCourse(CourseDTO course);
        public Course UpdateCourse(CourseDTO course, int id);
        public string DeleteCourse(int id);
        public void assign(Course course, CourseDTO dto);
        public void Save();
        public bool ValidatDepartement(int DepartmentId);
    }
}
