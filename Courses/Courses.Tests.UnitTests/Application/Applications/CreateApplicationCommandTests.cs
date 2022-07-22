namespace Courses.Tests.UnitTests.Application.Applications
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Courses.Core.Application.Features.Application.Commands;
    using Courses.Core.Contracts.Exceptions;
    using Courses.Core.Contracts.Interfaces;
    using Courses.Core.Contracts.Models.Participant;
    using Courses.Core.Domain.Entities;
    using FluentAssertions;
    using NUnit.Framework;
    using Telerik.JustMock;

    internal class CreateApplicationCommandTests
    {
        [Test]
        public async Task CreateApplicationCommand_WithInvalidCourse_ThrowsNotFoundException()
        {
            // Arrange
            ICoursesRepository _coursesRepository = Mock.Create<ICoursesRepository>();
            IApplicationsRepository _applicationsRepository = Mock.Create<IApplicationsRepository>();

            CreateApplicationCommand command = ApplicationsBuilder.CreateApplicationCommand(Arg.AnyGuid, ApplicationsHelper.CreateValidRequest());

            Mock.Arrange(() => _coursesRepository.GetCourseAsync(Arg.AnyGuid))
                .Returns(Task.FromResult((Course)null));

            CreateApplicationCommandHandler handler = new CreateApplicationCommandHandlerBuilder()
                                                       .WithCoursesRepository(_coursesRepository)
                                                       .WithApplicationsRepository(_applicationsRepository)
                                                       .Build();
            // Act
            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<NotFoundException>();

            Mock.Assert(() => _coursesRepository.GetCourseAsync(Arg.AnyGuid), Occurs.Once());
            Mock.Assert(() => _applicationsRepository.CreateApplicationAsync(null, Arg.AnyDateTime, Arg.AnyString, Arg.AnyString,
                Arg.AnyString, new List<CreateParticipantRequest>() { }), Occurs.Never());
        }
    }
}
