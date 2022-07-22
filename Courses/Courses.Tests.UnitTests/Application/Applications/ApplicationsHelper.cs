using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Core.Contracts.Models.Application;
using Courses.Core.Contracts.Models.Participant;

namespace Courses.Tests.UnitTests.Application.Applications
{
    internal class ApplicationsHelper
    {
        internal static CreateApplicationRequest CreateValidRequest()
        {
            return new CreateApplicationRequest
            {
                CompanyEmail = "test@test.com",
                CompanyName = "Google",
                CompanyNumber = "+38978222777",
                CourseDate = DateTime.Now,
                ParticipantsRequests = new List<CreateParticipantRequest>()
                {
                    new CreateParticipantRequest
                    {
                        Email = "nikola@test.com",
                        Name = "Nikola Stojkovski",
                        Number = "+38977234432"
                    }
                }
            };
        }
    }
}
