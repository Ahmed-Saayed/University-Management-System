using University_Management_System.Models.Entities;

namespace University_Management_System.Interfaces
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAll();
        public Task<List<string>> GetListOfCourses(int id);
        public Student GetStudById(int id);
        public Student AddStudent(StudentDTO student);
        public string AddCourse(int idSt, int idCou);
        public string DeleteCourse(int idSt, int idCou);
        public Student Update(StudentDTO student, int id);
        public string Delete(int id);
        public void Save();
        public void assign(Student st, StudentDTO dto);
        public bool ValidatFacultyAndDepartement(int FacultyId, int DepartmentId);

    }
}
