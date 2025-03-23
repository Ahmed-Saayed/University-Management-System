using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using University_Management_System.Interfaces;
using University_Management_System.Models.DataConnection;
using University_Management_System.Models.DTO;
using University_Management_System.Models.Entities;

namespace University_Management_System.Services
{
    public class AuthService : IAuthService
    {
        private readonly Data con;
        private IConfiguration config;
        public AuthService(Data con, IConfiguration config)
        {
            this.con = con;
            this.config = config;
        }

        public string GetTypeOfUser(string email)
        {
            if(con.Students.Any(o => o.Email == email))
            {
                return "Student";
            }
            else if (con.Users.Any(o => o.Email == email))
            {
                return "User";
            }
            else if (con.Instructors.Any(o => o.InstructorEmail == email))
            {
                return "Instructor";
            }
            else if (con.Managers.Any(o => o.Email == email))
            {
                return "Manager";
            }

            return "Invalid";
        }

        public bool Valid_User(UserDTO request)
        {
           var user = con.Users.FirstOrDefault(o => o.Email == request.Email);
            var man = con.Managers.FirstOrDefault(o => o.Email == request.Email);

            if ((user!=null &&new PasswordHasher<User>()
             .VerifyHashedPassword(user, user.HashedPassword, request.Password) == PasswordVerificationResult.Success)
             || (man != null && new PasswordHasher<Manager>()
             .VerifyHashedPassword(man, man.HashedPassword, request.Password) == PasswordVerificationResult.Success)
             ||GetTypeOfUser(request.Email) == "Instructor")
                return true;

            return false;
        }
        public string CreateToken(UserDTO user)
        {
            string role = GetTypeOfUser(user.Email);
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokendescription = new JwtSecurityToken(
                    issuer: config.GetValue<string>("AppSettings:Issuer"),
                    audience: config.GetValue<string>("AppSettings:Audience"),
                    claims: Claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                    );

            return new JwtSecurityTokenHandler().WriteToken(tokendescription);
        }

        public User Register(UserDTO request)
        {
            var ok = con.Users.FirstOrDefault(o => o.Email == request.Email);

            if (ok != null)
                return null;

            var user = new User();

            var hashedpass = new PasswordHasher<User>()
                                    .HashPassword(user, request.Password);

            user.Email = request.Email;
            user.HashedPassword = hashedpass;

            con.Users.Add(user);
            con.SaveChanges();

            return user;
        }

        public string Login(UserDTO request)
        {
            if (!Valid_User(request))
                return null;

            return "Hello you are logged in and this is your token  " + CreateToken(request);
        }

        public Manager AddManager(UserDTO request)
        {
            if(GetTypeOfUser(request.Email) == "Invalid")
            {
                var man = new Manager();

                var hashedpass = new PasswordHasher<Manager>()
                                        .HashPassword(man, request.Password);

                man.Email = request.Email;
                man.HashedPassword = hashedpass;

                con.Managers.Add(man);
                con.SaveChanges();

                return man;
            }

            return null;
        }
    }
}
