namespace Courses.Core.Application.Features.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Courses.Core.Contracts.Interfaces;
    using Courses.Core.Contracts.Models.Application;
    using MediatR;

    public class GetApplicationsQuery : IRequest<IEnumerable<ApplicationDto>>
    {
        public Guid CourseUid { get; }

        public GetApplicationsQuery(Guid courseUid)
        {
            CourseUid = courseUid;
        }
    }

    public class GetApplicationsQueryHandler : IRequestHandler<GetApplicationsQuery, IEnumerable<ApplicationDto>>
    {
        private readonly IApplicationsRepository _applicationsRepository;

        public GetApplicationsQueryHandler(IApplicationsRepository applicationsRepository)
        {
            _applicationsRepository = applicationsRepository;
        }

        public async Task<IEnumerable<ApplicationDto>> Handle(GetApplicationsQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<ApplicationDto> applications = await _applicationsRepository.GetApplicationsAsync(query.CourseUid);

            return applications;
        }
    }
}