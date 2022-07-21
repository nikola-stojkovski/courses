namespace Courses.Core.Contracts.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Courses.Core.Contracts.Models.Course;

    public interface ICoursesRepository
    {
        /// <summary>
        /// Returns all courses.
        /// </summary>
        Task<IEnumerable<CourseDto>> GetCoursesAsync();

        /// <summary>
        /// Creates course in the db.
        /// </summary>
        /// <param name="name">Name of the course.</param>
        /// <param name="dates">Dates for the course.</param>
        /// <returns>Uid of the course.</returns>
        Task<Guid> CreateCourseAsync(string name, IList<DateTime> dates);
    }
}
