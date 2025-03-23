using System.ComponentModel.DataAnnotations;

namespace University_Management_System.Models.Entities
{
    public class Manager
    {
        [Key]
        public string Email { get; set; }
        public string HashedPassword { get; set; }
    }
}
