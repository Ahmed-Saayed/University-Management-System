using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Emit;
using University_Management_System.Models.Entities;

namespace University_Management_System.Models.DataConnection
{
    public class Data :DbContext
    {
        public Data(DbContextOptions<Data> options) : base(options) { }

         protected override void OnConfiguring(DbContextOptionsBuilder op)
         {
             base.OnConfiguring(op);

             op.UseSqlServer("Server=localhost;Database=University;Trusted_Connection=True; TrustServerCertificate=True");
         }

        public string Email_Manager="HellowIamManager", PasswordManager = "passmanager";
        public DbSet<User> Users { get; set; }
        public DbSet<Student>Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }

        protected override void OnModelCreating(ModelBuilder op1)
        {
            op1.Entity<StudentCourse>(o =>
            {
                o.HasKey(o => new { o.CourseID, o.StudentID });
                o.HasOne(o => o.Student)
                .WithMany(o => o.StudentCourses)
                .HasForeignKey(o => o.StudentID);

                o.HasOne(o => o.Course)
               .WithMany(o => o.StudentCourses)
               .HasForeignKey(o => o.CourseID);
            });


            op1.Entity<Course>(o =>
            {
                o.HasOne(o => o.Instructor)
                .WithOne(o => o.Course)
                .HasForeignKey<Course>(o => o.InstructorCourse)
                .OnDelete(DeleteBehavior.Restrict);

                o.HasData(
                new Course { Id = 1, CourseName = ".Net", CourseCode = "IT101", CourseCost = 7000, CourseDepartment = 1, InstructorCourse = 1 },
                new Course { Id = 2, CourseName = ".JS", CourseCode = "IT151", CourseCost = 5000, CourseDepartment = 1, InstructorCourse = 2 }
                );
            });
   

            op1.Entity<Faculty>(o =>
            {
                o.HasMany(o => o.Departments)
                .WithOne(o => o.Faculty)
                .HasForeignKey(o => o.DepartmentFaculty)
                .OnDelete(DeleteBehavior.Restrict);

                o.HasMany(o => o.Students)
                .WithOne(o => o.Faculty)
                .HasForeignKey(o => o.StudentFaculty)
                .OnDelete(DeleteBehavior.Restrict);

                o.HasMany(o => o.Instructors)
                .WithOne(o => o.Faculty)
                .HasForeignKey(o => o.InstructorFaculty)
                .OnDelete(DeleteBehavior.Restrict);

                o.HasData(
                new Faculty { ID = 1, FacultyName = "Science" },
                new Faculty { ID = 2, FacultyName = "Computer Science" },
                new Faculty { ID = 3, FacultyName = "Dentisits" }
                );

            });

            op1.Entity<Department>(o =>
            {
                o.HasMany(o => o.Students)
                .WithOne(o => o.Department)
                .HasForeignKey(o => o.StudentDepartment)
                .OnDelete(DeleteBehavior.Restrict);

                o.HasMany(o => o.Instructors)
                .WithOne(o => o.Department)
                .HasForeignKey(o => o.InstructorDepartment)
                .OnDelete(DeleteBehavior.Restrict);

                o.HasMany(o => o.Courses)
                .WithOne(o => o.Department)
                .HasForeignKey(o => o.CourseDepartment)
                .OnDelete(DeleteBehavior.Restrict);

                o.HasData(
                new Department { Id = 1, Name = "IT", Description = "Focuse On Network", DepartmentFaculty = 1 },
                new Department { Id = 2, Name = "WebDev", Description = "Focuse On WebSites and Apis", DepartmentFaculty = 2 },
                new Department { Id = 3, Name = "Medical", Description = "Doctors Generations ", DepartmentFaculty = 3 }
                );
            });

            op1.Entity<Instructor>(o =>
            {
                o.HasData(
                 new Instructor { ID = 1, InstructorName = "Ashley", InstructorEmail = "Yahoo@gmail.com", InstructorFaculty = 1, InstructorDepartment = 1 },
                 new Instructor { ID = 2, InstructorName = "Noha", InstructorEmail = "Yahoo4@gmail.com", InstructorFaculty = 1, InstructorDepartment = 1 }
               );

            });
        }
    }
}
