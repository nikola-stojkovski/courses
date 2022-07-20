namespace Courses.Core.Contracts.Models.Course
{
    using System;
    using System.Collections.Generic;
    using Courses.Core.Contracts.Models.Common;

    public class CourseDto : RestBase
    {
        public string Name { get; set; }

        public IEnumerable<DateTime> Dates { get; set; }
    }
}
