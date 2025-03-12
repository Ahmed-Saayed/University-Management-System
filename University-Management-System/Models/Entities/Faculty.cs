namespace University_Management_System.Models.Entities
{
    public class Faculty
    {
        public int ID { get; set; }
        public string FacultyName { get; set; }
        public virtual List<Student>? Students { get; set; }
        public virtual List<Instructor>? Instructors { get; set; }
        public virtual List<Department>? Departments { get; set; }
    }
}