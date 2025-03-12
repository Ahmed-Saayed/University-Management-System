using University_Management_System.Models.DTO;
using University_Management_System.Models.Entities;

namespace University_Management_System.Services
{
    public interface IInstructorService
    {
        public Task<List<Instructor>> GetAll();
        public string GetCourse(int id);
        public Instructor GetInstById(int id);
        public Instructor AddInstructor(InstructorDTO ins);
        public Instructor UpdateInstructor(InstructorDTO ins,int id);
        public string DeleteInstructor(int id);
        public void assign(Instructor ins, InstructorDTO dto);
        public void Save();
        public bool ValidatFacultyAndDepartement(int FacultyId, int DepartmentId);
    }
}
