namespace Courses.Core.Contracts.Models.Application
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Courses.Core.Contracts.Models.Participant;

    public class CreateApplicationRequest
    {
        [Required]
        public DateTime CourseDate { get; set; }

        [Required]
        public string CompanyName { get; set; }
        
        [Required]
        [Phone]
        public string CompanyNumber { get; set; }

        [Required]
        [EmailAddress]
        public string CompanyEmail { get; set; }

        [Required]
        public IList<CreateParticipantRequest> ParticipantsRequests { get; set; }
    }
}
