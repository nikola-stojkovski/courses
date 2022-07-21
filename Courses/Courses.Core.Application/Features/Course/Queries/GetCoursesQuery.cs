namespace Courses.Core.Application.Features.Course.Queries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Courses.Core.Contracts.Interfaces;
    using Courses.Core.Contracts.Models.Course;
    using MediatR;

    public class GetCoursesQuery : IRequest<IEnumerable<CourseDto>>
    {
    }

    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IEnumerable<CourseDto>>
    {
        private readonly ICoursesRepository _coursesRepository;

        public GetCoursesQueryHandler(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public async Task<IEnumerable<CourseDto>> Handle(GetCoursesQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<CourseDto> courses = await _coursesRepository.GetCoursesAsync();

            return courses;
        }
    }
}
