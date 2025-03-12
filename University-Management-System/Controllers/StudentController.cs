using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_Management_System.Interfaces;
using University_Management_System.Models.Entities;

namespace University_Management_System.Controllers
{
    [Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentService studentService;
        IMapper map;
        public StudentController(IStudentService studentService, IMapper mp)
        {
            this.studentService = studentService;
            this.map = mp;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await studentService.GetAll();
            var ret = map.Map<List<StudentDTO>>(students); 

            return Ok(ret);
        }

        [HttpGet("Get courses of student/{id}")]
        public async Task<IActionResult> GetCoursesStudent(int id)
        {
            var lst = await studentService.GetListOfCourses(id);
            return  lst == null ? BadRequest() : Ok(lst);
        }

        [HttpGet("{id}")]
        public ActionResult GetStudent(int id)
        {
            var student = studentService.GetStudById(id);
            var ret = map.Map<StudentDTO>(student);

            return student == null ? NotFound() : Ok(ret);
        }
        
        [HttpPost]
        public IActionResult AddStudent([FromBody]StudentDTO student)
        {
            var studentAdded = studentService.AddStudent(student);
            var ret = map.Map<StudentDTO>(studentAdded);

            return studentAdded == null ? BadRequest() : Ok(ret);
        }

        [HttpPost("Add Course/{idSt}/{idCou}")]
        public  IActionResult AddCourse(int idSt, int idCou)
        {
            var CourseAdded =  studentService.AddCourse(idSt,idCou);

            return CourseAdded == null ? BadRequest() : Ok(CourseAdded);
        }

        [HttpPut("{id}")]
        public  IActionResult UpdateStudent(StudentDTO student,int id)
        {
            var studentUpdated =  studentService.Update(student,id);
            var ret = map.Map<StudentDTO>(studentUpdated);

            return studentUpdated == null ? BadRequest() : Ok(ret);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var studentDeleted = studentService.Delete(id);

            return studentDeleted == null ? BadRequest() : Ok(studentDeleted);
        }

        [HttpDelete("Delete Course/{idSt}/{idCou}")]
        public IActionResult DeleteCourse(int idSt,int idCou)
        {
            var CoursetDeleted = studentService.DeleteCourse(idSt,idCou);

            return CoursetDeleted == null ? BadRequest() : Ok(CoursetDeleted);
        }
    }
}
