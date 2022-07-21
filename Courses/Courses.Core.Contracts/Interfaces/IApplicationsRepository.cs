namespace Courses.Core.Contracts.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Courses.Core.Contracts.Models.Application;

    public interface IApplicationsRepository
    {
        /// <summary>
        /// Returns all applications for the specific course.
        /// </summary>
        /// <param name="courseUid">Course udi.</param>
        Task<IEnumerable<ApplicationDto>> GetApplicationsAsync(Guid courseUid);
    }
}
