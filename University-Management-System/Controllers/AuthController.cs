using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_Management_System.Interfaces;
using University_Management_System.Models.DataConnection;
using University_Management_System.Models.DTO;

namespace University_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       private readonly IAuthService _authService;
       private readonly IMapper mp;

        public AuthController(IAuthService authService ,IMapper mp)
        {
            _authService = authService;
            this.mp = mp;
 
        }


        [HttpPost("Register")]
        public IActionResult Register(UserDTO request)
        {
            var ret = _authService.Register(request);

            if(ret == null)
            {
                return BadRequest("User already exists");
            }

            var rett = mp.Map<UserDTO>(ret);
            return Ok(rett);
        }

        [HttpPost("Login")]
        public IActionResult Login(UserDTO request)
        {
            var ret = _authService.Login(request);

            if (ret == null)
            {
                return NotFound("Not Found User");
            }

            return Ok(ret);
        }
        [Authorize(Roles = "Manager")]
        [HttpPost("Add Manager")]
        public IActionResult AddManager(UserDTO request)
        {
            var man = _authService.AddManager(request);
            if (man == null)
                return BadRequest("Invalid Data");

            var rett = mp.Map<UserDTO>(man);
            return Ok(rett);
        }

    }
}
