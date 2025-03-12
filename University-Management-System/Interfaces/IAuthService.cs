using University_Management_System.Models.DTO;
using University_Management_System.Models.Entities;

namespace University_Management_System.Interfaces
{
    public interface IAuthService
    {
        public bool Valid_User(UserDTO req);
        public string CreateToken(User us);
        public string GetTypeOfUser(string s);
        public string Login(UserDTO req);
        public User Register(UserDTO req);
    }
}
