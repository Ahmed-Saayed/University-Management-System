using University_Management_System.Models.DTO;
using University_Management_System.Models.Entities;

namespace University_Management_System.Interfaces
{
    public interface IFacultyService
    {
        public Task<List<Faculty>> GetAllFaculties();
        public Task<List<string>> GetAllStudents(int id);
        public Task<List<string>> GetAllInstructors(int id);
        public Task<List<string>> GetAllDepartments(int id);
        public Faculty GetFacultyById(int id);
        public Faculty AddFaculty(FacultyDTO fac);
        public Faculty UpdateFaculty(FacultyDTO fac, int id);
        public string DeleteFaculty(int id);
        public void save();
    }
}
