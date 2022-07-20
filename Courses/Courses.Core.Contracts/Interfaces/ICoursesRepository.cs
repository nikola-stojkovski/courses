namespace Courses.Core.Contracts.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Courses.Core.Contracts.Models.Course;

    public interface ICoursesRepository
    {
        /// <summary>
        /// Returns all courses.
        /// </summary>
        Task<IEnumerable<CourseDto>> GetCourseDtos();
    }
}
