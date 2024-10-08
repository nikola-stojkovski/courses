﻿namespace Courses.Core.Contracts.Models.Application
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Courses.Core.Contracts.Models.Common;
    using Courses.Core.Contracts.Models.Participant;

    public class ApplicationDto : RestBase
    {
        public string CourseName { get; set; }

        public DateTime CourseDate { get; set; }

        public string CompanyName { get; set; }

        public string CompanyNumber { get; set; }

        public string CompanyEmail { get; set; }

        public IEnumerable<ParticipantDto> Participants { get; set; }
    }
}
