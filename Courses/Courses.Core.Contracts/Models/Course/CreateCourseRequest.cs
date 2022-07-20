namespace Courses.Core.Contracts.Models.Course
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateCourseRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public IList<DateTime> Dates { get; set; }
    }
}
