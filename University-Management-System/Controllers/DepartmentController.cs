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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;
        private readonly IMapper mp;
        public DepartmentController(IDepartmentService departmentService, IMapper mp)
        {
            this.departmentService = departmentService;
            this.mp = mp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var lst = await departmentService.GetAllDepartments();

            var ret = mp.Map<List<DepartmentDTO>>(lst);

            return Ok(ret);
        }
        [HttpGet("GetAllCourses/{id}")]
        public async Task<IActionResult> GetAllCourses(int id)
        {
            var lst = await departmentService.GetAllCourses(id);

            return Ok(lst);
        }
        [HttpGet("GetAllStudents/{id}")]
        public async Task<IActionResult> GetAllStudents(int id)
        {
            var lst = await departmentService.GetAllStudents(id);

            return Ok(lst);
        }
        [HttpGet("GetAllInstructors/{id}")]
        public async Task<IActionResult> GetAllInstructors(int id)
        {
            var lst = await departmentService.GetAllInstructors(id);

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            var dep = departmentService.GetDepartmentById(id);
            var ret = mp.Map<DepartmentDTO>(dep);

            return dep == null ? BadRequest() : Ok(ret);
        }

        [HttpPost]
        public IActionResult AddDepartment(DepartmentDTO depdto)
        {
            var dep = departmentService.AddDepartment(depdto);
            var ret = mp.Map<DepartmentDTO>(dep);

            return dep == null ? BadRequest() : Ok(ret);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(DepartmentDTO depdto, int id)
        {
            var dep = departmentService.UpdateDepartment(depdto, id);
            var ret = mp.Map<DepartmentDTO>(dep);

            return dep == null ? BadRequest() : Ok(ret);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var ret = departmentService.DeleteDepartment(id);
            return ret == null ? NotFound() : Ok(ret);
        }
    }
}
