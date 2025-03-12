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
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService facultyService;
        private readonly IMapper mp;

        public FacultyController(IFacultyService facultyService , IMapper mp)
        {
            this.mp = mp;
            this.facultyService = facultyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFaculties()
        {
            var faculties = await facultyService.GetAllFaculties();

            var ret = mp.Map<List<FacultyDTO>>(faculties);

            return Ok(ret);
        }

        [HttpGet("GetAllDepartment/{id}")]
        public async Task<IActionResult> GetAllDepartment(int id)
        {
            var dep = await facultyService.GetAllDepartments(id);

            return Ok(dep);
        }

        [HttpGet("GetAllStudents/{id}")]
        public async Task<IActionResult> GetAllStudents(int id)
        {
            var sts = await facultyService.GetAllStudents(id);

            return Ok(sts);
        }

        [HttpGet("GetAllInstructors/{id}")]
        public async Task<IActionResult> GetAllInstructors(int id)
        {
            var ins = await facultyService.GetAllInstructors(id);

            return Ok(ins);
        }

        [HttpGet("{id}")]
        public IActionResult GetFacultyById(int id)
        {
            var faculty = facultyService.GetFacultyById(id);

            var ret = mp.Map<FacultyDTO>(faculty);

            return Ok(ret);
        }
        [HttpPost]
        public IActionResult AddFaculty(FacultyDTO fac)
        {
            var faculty = facultyService.AddFaculty(fac);

            var ret = mp.Map<FacultyDTO>(faculty);

            return Ok(ret);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateFaculty(FacultyDTO fac, int id)
        {
            var faculty = facultyService.UpdateFaculty(fac, id);

            var ret = mp.Map<FacultyDTO>(faculty);

            return Ok(ret);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFaculty(int id)
        {
            var faculty = facultyService.DeleteFaculty(id);

            return Ok(faculty);
        }
    }
}
