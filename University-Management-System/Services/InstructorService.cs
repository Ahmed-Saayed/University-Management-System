using Microsoft.EntityFrameworkCore;
using University_Management_System.Interfaces;
using University_Management_System.Models.DataConnection;
using University_Management_System.Models.DTO;
using University_Management_System.Models.Entities;

namespace University_Management_System.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly Data con;
        public InstructorService(Data con)
        {
            this.con = con;
        }
        public async Task<List<Instructor>> GetAll()
        {
            return await con.Instructors.ToListAsync();
        }
        public string GetCourse(int id)
        {
            return con.Courses.FirstOrDefault(o => o.InstructorCourse == id).CourseName;
        }

        public Instructor GetInstById(int id)
        {
            return con.Instructors.Find(id);
        }
        public Instructor AddInstructor(InstructorDTO ins)
        {
            if(GetInstById(ins.ID) != null 
                || !ValidatFacultyAndDepartement(ins.InstructorFaculty ,ins.InstructorDepartment))
                return null;

            var Instructor = new Instructor();
            
            assign(Instructor, ins);
            con.Instructors.Add(Instructor);
            Save();

            return Instructor;
        }
        public Instructor UpdateInstructor(InstructorDTO ins,int id)
        {
            if (GetInstById(id) == null
                || !ValidatFacultyAndDepartement(ins.InstructorFaculty, ins.InstructorDepartment))
                return null;

            var UpIns = GetInstById(ins.ID);

            assign(UpIns, ins);
            con.Instructors.Update(UpIns);
            Save();

            return UpIns;
        }

        public string DeleteInstructor(int id)
        {
            if(GetInstById(id) == null)
                return null;

            con.Instructors.Remove(GetInstById(id));
            Save();

            return "Instructor Deleted";
        }

        public void assign(Instructor ins, InstructorDTO dto)
        {
            ins.InstructorName = dto.InstructorName;
            ins.InstructorFaculty = dto.InstructorFaculty;
            ins.InstructorDepartment = dto.InstructorDepartment;
            ins.InstructorEmail = dto.InstructorEmail;
        }

        public void Save()
        {
            con.SaveChanges();
        }
        public bool ValidatFacultyAndDepartement(int FacultyId, int DepartmentId)
        {
            return con.Faculties.Find(FacultyId) != null 
                && con.Departments.Find(DepartmentId) != null
                && con.Departments.Find(DepartmentId).DepartmentFaculty == FacultyId;
        }
    }
}
