using University_Management_System.Models.DTO;
using University_Management_System.Models.Entities;

namespace University_Management_System.Interfaces
{
    public interface IDepartmentService
    {
        public Task<List<Department>> GetAllDepartments();
        public Task<List<string>> GetAllStudents(int id);
        public Task<List<string>> GetAllInstructors(int id);
        public Task<List<string>> GetAllCourses(int id);
        public Department GetDepartmentById(int id);
        public Department AddDepartment(DepartmentDTO Dep);
        public Department UpdateDepartment(DepartmentDTO Dep, int id);
        public string DeleteDepartment(int id);
        public void assign(Department dep, DepartmentDTO depdto);
        public void save();
        public bool ValidFaculty(int id);
    }
}
