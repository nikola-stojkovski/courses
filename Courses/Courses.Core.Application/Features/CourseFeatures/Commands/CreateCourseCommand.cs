namespace Courses.Core.Application.Features.CourseFeatures.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Courses.Core.Contracts;
    using Courses.Core.Contracts.Exceptions;
    using Courses.Core.Contracts.Interfaces;
    using Courses.Core.Contracts.Models.Course;
    using MediatR;

    public class CreateCourseCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public IList<DateTime> Dates { get; set; }

        public CreateCourseCommand(CreateCourseRequest request)
        {
            Name = request.Name;
            Dates = request.Dates;
        }
    }

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
    {
        private readonly ICoursesRepository _coursesRepository;

        public CreateCourseCommandHandler(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public async Task<Guid> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
        {
            bool anyDuplicateDate = command.Dates.GroupBy(x => x.Date).Any(x => x.Count() > 1);
            
            if (anyDuplicateDate)
            {
                throw new InvalidValueException(ErrorMessages.INVALID_COURSE_DATES);
            }

            Guid courseUid = await _coursesRepository.CreateCourse(name: command.Name,
                                                                   dates: command.Dates);

            return courseUid;
        }
    }
}
