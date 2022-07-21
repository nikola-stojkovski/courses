namespace Courses.Core.Application.Features.Application.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Courses.Core.Contracts.Interfaces;
    using Courses.Core.Contracts.Models.Application;
    using Courses.Core.Contracts.Models.Participant;
    using Courses.Core.Domain.Entities;
    using Courses.Core.Contracts.Exceptions;
    using MediatR;
    using Courses.Core.Contracts;
    using System.Linq;

    public class CreateApplicationCommand : IRequest<Guid>
    {
        public Guid CourseUid { get; }

        public DateTime CourseDate { get; }

        public string CompanyName { get; }

        public string CompanyNumber { get; }

        public string CompanyEmail { get; }

        public IList<CreateParticipantRequest> ParticipantsRequests { get; }

        public CreateApplicationCommand(Guid courseUid, CreateApplicationRequest request)
        {
            CourseUid = courseUid;
            CourseDate = request.CourseDate;
            CompanyName = request.CompanyName;
            CompanyNumber = request.CompanyNumber;
            CompanyEmail = request.CompanyEmail;
            ParticipantsRequests = request.ParticipantsRequests;
        }
    }

    public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, Guid>
    {
        private readonly ICoursesRepository _coursesRepository;
        private readonly IApplicationsRepository _applicationsRepository;

        public CreateApplicationCommandHandler(ICoursesRepository coursesRepository,
                                               IApplicationsRepository applicationsRepository)
        {
            _coursesRepository = coursesRepository;
            _applicationsRepository = applicationsRepository;
        }

        public async Task<Guid> Handle(CreateApplicationCommand command, CancellationToken cancellationToken)
        {
            Course course = await _coursesRepository.GetCourseAsync(command.CourseUid);

            if (course == null)
            {
                throw new NotFoundException(ErrorMessages.COURSE_NOT_FOUND);
            }

            bool checkDateValidity = course.Dates.Contains(command.CourseDate);

            if (!checkDateValidity)
            {
                throw new InvalidValueException(ErrorMessages.INVALID_COURSE_DATES);
            }

            bool checkParticipantEmailDuplicates = command.ParticipantsRequests.GroupBy(x => x.Email)
                                                                               .Any(x => x.Count() > 1);

            if (checkParticipantEmailDuplicates)
            {
                throw new InvalidValueException(ErrorMessages.INVALID_PARTICIPANT_EMAIL_VALUE);
            }

            Guid applicationUid = await _applicationsRepository.CreateApplicationAsync(course: course,
                                                                                       courseDate: command.CourseDate,
                                                                                       companyName: command.CompanyName,
                                                                                       companyNumber: command.CompanyNumber,
                                                                                       companyEmail: command.CompanyEmail,
                                                                                       participantRequests: command.ParticipantsRequests);

            return applicationUid;
        }
    }
}