using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_Management_System.Models.DTO;
using University_Management_System.Models.Entities;
using University_Management_System.Services;

namespace University_Management_System.Controllers
{
    [Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService InstructorServices;
        private readonly IMapper map;
        public InstructorController(IInstructorService InstructorService, IMapper map)
        {
            this.InstructorServices = InstructorService;
            this.map = map;
        }

        [HttpGet]
        public async Task<IActionResult> GetInstructors()
        {
            var instructors = await InstructorServices.GetAll();
            var ret = map.Map<List<InstructorDTO>>(instructors);

            return Ok(ret);
        }

        [HttpGet("Get course of Instructor/{id}")]
        public IActionResult GetCoursesStudent(int id)
        {
            var course =  InstructorServices.GetCourse(id);
            return course == null ? BadRequest() : Ok(course);
        }

        [HttpGet("{id}")]
        public ActionResult GetInstructor(int id)
        {
            var Instructor = InstructorServices.GetInstById(id);
            var ret = map.Map<InstructorDTO>(Instructor);

            return Instructor == null ? NotFound() : Ok(ret);
        }


        [HttpPost]
        public IActionResult AddInstructor([FromBody] InstructorDTO ins)
        {
            var InstAdded = InstructorServices.AddInstructor(ins);
            var ret = map.Map<InstructorDTO>(InstAdded);

            return InstAdded == null ? BadRequest() : Ok(ret);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(InstructorDTO ins, int id)
        {
            var InsUpdated = InstructorServices.UpdateInstructor(ins, id);
            var ret = map.Map<InstructorDTO>(InsUpdated);

            return InsUpdated == null ? BadRequest() : Ok(ret);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInstructor(int id)
        {
            var InstructorDeleted = InstructorServices.DeleteInstructor(id);

            return InstructorDeleted == null ? BadRequest() : Ok(InstructorDeleted);
        }
    }
}
