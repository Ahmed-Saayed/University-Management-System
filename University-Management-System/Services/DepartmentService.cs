using Microsoft.EntityFrameworkCore;
using University_Management_System.Models.DataConnection;
using University_Management_System.Models.DTO;
using University_Management_System.Models.Entities;

namespace University_Management_System.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly Data con;
        public DepartmentService(Data con)
        {
            this.con = con;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await con.Departments.ToListAsync();
        }
        public async Task<List<string>> GetAllCourses(int id)
        {
            return await con.Courses.Where(o => o.CourseDepartment == id).Select(o => o.CourseName).ToListAsync();
        }
        public async Task<List<string>> GetAllInstructors(int id)
        {
            return await con.Instructors.Where(o => o.InstructorDepartment == id).Select(o => o.InstructorName).ToListAsync();
        }

        public async Task<List<string>> GetAllStudents(int id)
        {
            return await con.Students.Where(o => o.StudentDepartment == id).Select(o => o.FirstName).ToListAsync();
        }

        public Department GetDepartmentById(int id)
        {
            return con.Departments.Find(id);
        }
        public Department AddDepartment(DepartmentDTO depdto)
        {
            if (GetDepartmentById(depdto.Id) != null
                || !ValidFaculty(depdto.DepartmentFaculty))
                return null;

            var NewDepartment = new Department();
            assign(NewDepartment, depdto);
            con.Departments.Add(NewDepartment);
            save();

            return NewDepartment;
        }
        public Department UpdateDepartment(DepartmentDTO depdto, int id)
        {
            if (GetDepartmentById(id) == null
                || !ValidFaculty(depdto.DepartmentFaculty))
                return null;

            var UpDepartment = new Department();

            assign(UpDepartment, depdto);
            con.Departments.Update(UpDepartment);
            save();

            return UpDepartment;
        }
        public string DeleteDepartment(int id)
        {
            if(GetDepartmentById(id) == null)
                return null;

            con.Departments.Remove(GetDepartmentById(id));
            save();

            return "Department Deleted";
        }
        public void save()
        {
            con.SaveChanges();
        }
        public void assign(Department dep, DepartmentDTO depdto)
        {
            dep.Name = depdto.Name;
            dep.DepartmentFaculty = depdto.DepartmentFaculty;
            dep.Description = depdto.Description;
        }
        public bool ValidFaculty(int id)
        {
            return con.Faculties.Find(id) != null;
        }
    }
}
