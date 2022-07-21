namespace Courses.Core.Application.Features.Application.Queries
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Courses.Core.Contracts;
    using Courses.Core.Contracts.Interfaces;
    using FluentValidation;

    public class GetApplicationsQueryValidator : AbstractValidator<GetApplicationsQuery>
    {
        private readonly ICoursesRepository _coursesRepository;

        public GetApplicationsQueryValidator(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;

            RuleFor(r => r.CourseUid)
                .NotNull()
                .MustAsync(ExistCourse)
                .WithMessage(ErrorMessages.COURSE_NOT_FOUND);
        }

        private async Task<bool> ExistCourse(Guid courseUid, CancellationToken cancellationToken)
        {
            return await _coursesRepository.CheckCourseExistAsync(courseUid);
        }
    }
}
