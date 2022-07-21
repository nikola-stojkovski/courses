namespace Courses.Core.Contracts.Models.Participant
{
    using System.ComponentModel.DataAnnotations;

    public class CreateParticipantRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Number { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
