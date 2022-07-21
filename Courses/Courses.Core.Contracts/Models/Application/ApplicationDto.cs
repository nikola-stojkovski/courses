namespace Courses.Core.Contracts.Models.Application
{
    using System;
    using Courses.Core.Contracts.Models.Common;

    public class ApplicationDto : RestBase
    {
        public string CourseName { get; set; }

        public DateTime CourseDate { get; set; }

        public string CompanyName { get; set; }

        public string CompanyPhone { get; set; }

        public string CompanyEmail { get; set; }
    }
}
