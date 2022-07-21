namespace Courses.Core.Contracts.Mappings
{
    using AutoMapper;
    using Courses.Core.Contracts.Models.Application;
    using Courses.Core.Contracts.Models.Course;
    using Courses.Core.Domain.Entities;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<Application, ApplicationDto>();
        }
    }
}
