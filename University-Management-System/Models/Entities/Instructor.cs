namespace University_Management_System.Models.Entities
{
    public class Instructor
    {
        public int ID { get; set; }
        public string InstructorName { get; set; }
        public string InstructorEmail { get; set; }
        public virtual Course Course { get; set; }
        public int InstructorDepartment { get; set; }
        public virtual Department? Department { get; set; }
        public int InstructorFaculty { get; set; }
        public virtual Faculty? Faculty { get; set; }
    }
}