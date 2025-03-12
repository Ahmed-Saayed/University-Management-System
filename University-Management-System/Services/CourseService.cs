using Microsoft.EntityFrameworkCore;
using University_Management_System.Interfaces;
using University_Management_System.Models.DataConnection;
using University_Management_System.Models.DTO;
using University_Management_System.Models.Entities;

namespace University_Management_System.Services
{
    public class CourseService : ICourseService
    {
        private readonly Data con;
        public CourseService(Data con)
        {
            this.con = con;
        }

        public async Task<List<Course>> GetAll()
        {
            return await con.Courses.ToListAsync();
        }

        public Course GetCourseById(int id)
        {
            return con.Courses.Find(id);
        }
        public Course AddCourse(CourseDTO course)
        {
            if(GetCourseById(course.Id) != null
                ||!ValidatDepartement(course.CourseDepartment))
                return null;

            var NewCourse = new Course();
            
            assign(NewCourse, course);
            con.Courses.Add(NewCourse);
            Save();

            return NewCourse;
        }
        public Course UpdateCourse(CourseDTO course, int id)
        {
            if (GetCourseById(id) == null
                || !ValidatDepartement(course.CourseDepartment))
                return null;

            var UpCourse = GetCourseById(id);

            assign(UpCourse, course);
            con.Courses.Update(UpCourse);
            Save();

            return UpCourse;
        }
        public string DeleteCourse(int id)
        {
            if(GetCourseById(id) == null)
                return null;

            con.Courses.Remove(con.Courses.Find(id));
            Save();

            return "Course Deleted";
        }
     
        public void assign(Course course, CourseDTO dto)
        {
            course.CourseName = dto.CourseName;
            course.CourseDepartment = dto.CourseDepartment;
            course.InstructorCourse = dto.InstructorCourse;
            course.CourseCost = dto.CourseCost;
            course.CourseCode = dto.CourseCode;
        }

        public void Save()
        {
            con.SaveChanges();
        }
        public bool ValidatDepartement(int DepartmentId)
        {
            return con.Departments.Find(DepartmentId) != null;
        }

    }
}
