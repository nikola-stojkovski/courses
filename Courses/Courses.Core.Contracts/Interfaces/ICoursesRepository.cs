namespace Courses.Core.Contracts.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Courses.Core.Contracts.Models.Course;
    using Courses.Core.Domain.Entities;

    public interface ICoursesRepository
    {
        /// <summary>
        /// Returns all courses.
        /// </summary>
        Task<IEnumerable<CourseDto>> GetCoursesAsync();

        /// <summary>
        /// Returns specific course.
        /// </summary>
        /// <param name="courseUid">Course uid.</param>
        Task<Course> GetCourseAsync(Guid courseUid);

        /// <summary>
        /// Creates course in the db.
        /// </summary>
        /// <param name="name">Name of the course.</param>
        /// <param name="dates">Dates for the course.</param>
        /// <returns>Uid of the course.</returns>
        Task<Guid> CreateCourseAsync(string name, IList<DateTime> dates);

        /// <summary>
        /// Checks if the course with provided Uid exist in the system.
        /// </summary>
        /// <param name="courseUid">Course Uid.</param>
        Task<bool> CheckCourseExistAsync(Guid courseUid);
    }
}
