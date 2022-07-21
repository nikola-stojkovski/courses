namespace Courses.Core.Application.Features.Course.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Courses.Core.Contracts;
    using FluentValidation;

    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(r => r.Dates)
                .NotNull()
                .Must(HasUniqueDates)
                .WithMessage(ErrorMessages.INVALID_COURSE_DATES);
        }

        private bool HasUniqueDates(IList<DateTime> dates)
        {
            return dates.GroupBy(x => x.Date)
                        .All(x => x.Count() == 1);
        }
    }
}
