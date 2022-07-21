namespace Courses.Core.Contracts.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Courses.Core.Contracts.Models.Application;
    using Courses.Core.Contracts.Models.Participant;
    using Courses.Core.Domain.Entities;

    public interface IApplicationsRepository
    {
        /// <summary>
        /// Returns all applications for the specific course.
        /// </summary>
        /// <param name="courseUid">Course udi.</param>
        Task<IEnumerable<ApplicationDto>> GetApplicationsAsync(Guid courseUid);

        /// <summary>
        /// Creates application with participants for course on specific date.
        /// </summary>
        /// <param name="course">Course db entity.</param>
        /// <param name="courseDate">Course date.</param>
        /// <param name="companyName">Company name.</param>
        /// <param name="companyNumber">Company number.</param>
        /// <param name="companyEmail">Company email</param>
        /// <param name="participantRequests">Participants requests.</param>
        /// <returns></returns>
        Task<Guid> CreateApplicationAsync(Course course, DateTime courseDate, string companyName, string companyNumber,
             string companyEmail, IList<CreateParticipantRequest> participantRequests);
    }
}
