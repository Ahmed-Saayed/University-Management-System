namespace University_Management_System.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentFaculty { get; set; }
        public virtual Faculty? Faculty { get; set; }
        public virtual List<Course>? Courses { get; set; }
        public virtual List<Student>? Students { get; set; }
        public virtual List<Instructor>? Instructors { get; set; }
    }
}
