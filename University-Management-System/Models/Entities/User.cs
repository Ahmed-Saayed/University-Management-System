namespace University_Management_System.Models.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
    }
}
