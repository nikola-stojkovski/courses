namespace Courses.Core.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Courses.Core.Domain.Common;

    public class Application : BaseEntity
    {
        [Required]
        public string CourseName { get; set; }

        [Required]
        public DateTime CourseDate { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string CompanyNumber { get; set; }

        [Required]
        public string CompanyEmail { get; set; }

        [Required]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
