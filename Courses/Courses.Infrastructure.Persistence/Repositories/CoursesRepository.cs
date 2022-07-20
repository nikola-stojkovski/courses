namespace Courses.Infrastructure.Persistence.Repositories
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Courses.Core.Contracts.Interfaces;
    using Courses.Core.Contracts.Models.Course;
    using Courses.Core.Domain.Entities;
    using Courses.Infrastructure.Persistence.Context;
    using Microsoft.EntityFrameworkCore;

    public class CoursesRepository : ICoursesRepository
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CoursesRepository(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDto>> GetCourseDtos()
        {
            IEnumerable<CourseDto> courses = await _dbContext.Courses.AsNoTracking()
                                                                     .ProjectTo<CourseDto>(_mapper.ConfigurationProvider)
                                                                     .ToArrayAsync();

            return courses;
        }

        public async Task<Guid> CreateCourse(string name, IList<DateTime> dates)
        {
            Course course = new()
            {
                Uid = Guid.NewGuid(),
                Name = name,
                Dates = dates
            };

            _dbContext.Courses.Add(course);

            await _dbContext.SaveChanges();

            return course.Uid;
        }
    }
}
