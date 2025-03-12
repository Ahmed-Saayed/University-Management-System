using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_Management_System.Interfaces;
using University_Management_System.Models.DTO;

namespace University_Management_System.Controllers
{
    [Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;
        private readonly IMapper map;
        public CourseController(ICourseService courseService, IMapper map)
        {
            this.courseService = courseService;
            this.map = map;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await courseService.GetAll();
            var ret = map.Map<List<CourseDTO>>(courses);

            return courses == null ? BadRequest() : Ok(ret);
        }

        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            var course = courseService.GetCourseById(id);
            var ret = map.Map<CourseDTO>(course);

            return course == null ? NotFound() : Ok(ret);
        }

        [HttpPost]
        public IActionResult AddCourse(CourseDTO course)
        {
            var NewCourse = courseService.AddCourse(course);
            var ret = map.Map<CourseDTO>(NewCourse);

            return NewCourse == null ? BadRequest() : Ok(ret);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(CourseDTO course, int id)
        {
            var UpCourse = courseService.UpdateCourse(course, id);
            var ret = map.Map<CourseDTO>(UpCourse);

            return UpCourse == null ? BadRequest() : Ok(ret);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var del = courseService.DeleteCourse(id);

            return del == null ? BadRequest() : Ok(del);
        }
    }
}
