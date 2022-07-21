namespace Courses.Core.Contracts.Models.Participant
{
    using Courses.Core.Contracts.Models.Common;

    public class ParticipantDto : RestBase
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public string Email { get; set; }
    }
}
