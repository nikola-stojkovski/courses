namespace Courses.Core.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Courses.Core.Domain.Common;

    public class Course : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public IList<DateTime> Dates { get; set; }
    }
}
