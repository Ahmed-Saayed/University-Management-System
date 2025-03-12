using Microsoft.EntityFrameworkCore;
using University_Management_System.Models.DataConnection;
using University_Management_System.Models.Entities;

namespace University_Management_System.Services
{
    public class StudentService : IStudentService
    {
       private readonly Data con;
        public StudentService(Data con)
        {
            this.con = con;
        }
        public async Task<List<Student>> GetAll()
        {
            return await con.Students.ToListAsync();
        }
        public async Task<List<string>> GetListOfCourses(int id)
        {
            if (GetStudById(id) == null)
                return null;

            var lst =  con.StudentCourses.Where(x => x.StudentID == id).Select(x => x.CourseID).ToList();
            return lst.Select(x => con.Courses.Find(x).CourseName).ToList();
        }

        public Student GetStudById(int id)
        {
            return con.Students.Find(id);
        }
        public Student AddStudent(StudentDTO studentDTO)
        {
            if(GetStudById(studentDTO.Id) != null
                || !ValidatFacultyAndDepartement(studentDTO.StudentFaculty, studentDTO.StudentDepartment))
                return null;

           var NewStudent = new Student();

           assign(NewStudent, studentDTO);

            con.Students.Add(NewStudent);
            Save();

           return NewStudent;
        }
        public string AddCourse(int idSt, int idCou)
        {
            if(GetStudById(idSt) == null || con.Courses.Find(idCou) == null
                || con.StudentCourses.FirstOrDefault(o=>o.StudentID==idSt&&o.CourseID==idCou) != null)
                return null;

            con.StudentCourses.Add(new StudentCourse {CourseID = idCou ,StudentID = idSt });
            Save();

            return  $"Course Added to Student {con.Students.Find(idSt).FirstName}";
        }
        public string DeleteCourse(int idSt, int idCou)
        {
            var coursestudent = con.StudentCourses.Find(idCou, idSt);
            if (GetStudById(idSt) == null || con.Courses.Find(idCou) == null || coursestudent == null)
                return null;

            con.StudentCourses.Remove(coursestudent);
             Save();

            return $"Course Deleted Succefully";
        }
        public Student Update(StudentDTO studentDTO, int id)
        {
            if (GetStudById(id) == null 
                || !ValidatFacultyAndDepartement(studentDTO.StudentFaculty,studentDTO.StudentDepartment))
                 return null;

            var UpStudent = con.Students.Find(id);

            assign(UpStudent, studentDTO);

            con.Students.Update(UpStudent); 
            Save();

            return UpStudent;
        }
        public  string Delete(int id)
        {
            if(GetStudById(id) == null)
                return null;

            con.Students.Remove(con.Students.Find(id));
            Save();

            return "User Deleted";
        }

        public void assign(Student st,StudentDTO dto)
        {
            st.FirstName = dto.FirstName;
            st.SecondName = dto.SecondName;
            st.StudentFaculty = dto.StudentFaculty;
            st.StudentDepartment = dto.StudentDepartment;
            st.Email = dto.Email;
            st.Phone = dto.Phone;
            st.Address = dto.Address;
            st.Gender = dto.Gender;
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
