using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Core.Application.Features.Application.Commands;
using Courses.Core.Contracts.Interfaces;
using Courses.Core.Contracts.Models.Application;

namespace Courses.Tests.UnitTests.Application.Applications
{
    internal static class ApplicationsBuilder
    {
        internal static CreateApplicationCommand CreateApplicationCommand(Guid courseId, CreateApplicationRequest request)
        {
            return new CreateApplicationCommand(courseId, request);
        }
    }

    internal class CreateApplicationCommandHandlerBuilder
    {
        private ICoursesRepository _coursesRepository;
        private IApplicationsRepository _applicationsRepository;

        internal CreateApplicationCommandHandlerBuilder WithCoursesRepository(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
            return this;
        }

        internal CreateApplicationCommandHandlerBuilder WithApplicationsRepository(IApplicationsRepository applicationsRepository)
        {
            _applicationsRepository = applicationsRepository;
            return this;
        }

        internal CreateApplicationCommandHandler Build()
        {
            return new CreateApplicationCommandHandler(_coursesRepository, _applicationsRepository);
        }
    }
}
