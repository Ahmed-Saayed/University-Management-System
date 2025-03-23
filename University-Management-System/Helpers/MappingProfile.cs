using AutoMapper;
using University_Management_System.Models.DTO;
using University_Management_System.Models.Entities;
using University_Management_System.Services;

namespace University_Management_System.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student,StudentDTO>();
            CreateMap<Instructor, InstructorDTO>();
            CreateMap<Course, CourseDTO>();
            CreateMap<Department, DepartmentDTO>();
            CreateMap<Faculty, FacultyDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<Manager, UserDTO>();
        }
    }
}
