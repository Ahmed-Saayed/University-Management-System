using Microsoft.EntityFrameworkCore;
using University_Management_System.Interfaces;
using University_Management_System.Models.DataConnection;
using University_Management_System.Models.DTO;
using University_Management_System.Models.Entities;

namespace University_Management_System.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly Data con;
        public FacultyService(Data con)
        {
            this.con = con;
        }
        public async Task<List<Faculty>> GetAllFaculties()
        {
            return await con.Faculties.ToListAsync();
        }
        public async Task<List<string>> GetAllDepartments(int id)
        {
            return await con.Departments.Where(o => o.DepartmentFaculty == id).Select(o => o.Name).ToListAsync();
        }
        public async Task<List<string>> GetAllInstructors(int id)
        {
            return await con.Instructors.Where(o => o.InstructorDepartment == id).Select(o => o.InstructorName).ToListAsync();
        }

        public async Task<List<string>> GetAllStudents(int id)
        {
            return await con.Students.Where(o => o.StudentDepartment == id).Select(o => o.FirstName).ToListAsync();
        }

        public Faculty GetFacultyById(int id)
        {
            return con.Faculties.Find(id);
        }
        public Faculty AddFaculty(FacultyDTO fac)
        {
            if (GetFacultyById(fac.ID) != null)
                return null;

            var Newfaculty = new Faculty();
            Newfaculty.FacultyName = fac.FacultyName;

            con.Faculties.Add(Newfaculty);
            save();

            return Newfaculty;
        }
        public Faculty UpdateFaculty(FacultyDTO fac, int id)
        {
            if (GetFacultyById(id) == null)
                return null;

            var Upfaculty = GetFacultyById(id);
            Upfaculty.FacultyName = fac.FacultyName;

            con.Faculties.Update(Upfaculty);
            save();

            return Upfaculty;
        }
        public string DeleteFaculty(int id)
        {
            if (GetFacultyById(id) == null)
                return null;
            
            con.Faculties.Remove(GetFacultyById(id));
            save();

            return "Faculty Deleted";
        }
        public void save()
        {
            con.SaveChanges();
        }

    }
}
