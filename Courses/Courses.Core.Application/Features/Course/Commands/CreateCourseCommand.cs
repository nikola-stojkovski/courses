namespace Courses.Core.Application.Features.Course.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Courses.Core.Contracts.Interfaces;
    using Courses.Core.Contracts.Models.Course;
    using MediatR;

    public class CreateCourseCommand : IRequest<Guid>
    {
        public string Name { get; }

        public IList<DateTime> Dates { get; }

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
            Guid courseUid = await _coursesRepository.CreateCourseAsync(name: command.Name,
                                                                        dates: command.Dates);

            return courseUid;
        }
    }
}
