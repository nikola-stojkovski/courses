namespace Courses.Infrastructure.Persistence.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Courses.Core.Contracts.Interfaces;
    using Courses.Core.Contracts.Models.Application;
    using Courses.Core.Domain.Entities;
    using Courses.Infrastructure.Persistence.Context;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationsRepository : IApplicationsRepository
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ApplicationsRepository(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationDto>> GetApplicationsAsync(Guid courseUid)
        {
            IQueryable<Application> applicationsQuery = from dbCourse in _dbContext.Courses.AsNoTracking()
                                                                                           .Where(x => x.Uid == courseUid)
                                                        join dbApplication in _dbContext.Applications.AsNoTracking()
                                                        on dbCourse.Id equals dbApplication.CourseId
                                                        select dbApplication;

            IEnumerable<ApplicationDto> applications = applicationsQuery.ProjectTo<ApplicationDto>(_mapper.ConfigurationProvider);

            return applications;
        }
    }
}
