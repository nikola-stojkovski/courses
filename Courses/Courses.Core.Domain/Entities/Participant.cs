using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Courses.Core.Domain.Common;

namespace Courses.Core.Domain.Entities
{
    public class Participant : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int ApplicationId { get; set; }

        public virtual Application Application { get; set; }
    }
}
