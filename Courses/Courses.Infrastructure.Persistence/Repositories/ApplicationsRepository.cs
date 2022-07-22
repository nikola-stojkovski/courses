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
    using Courses.Core.Contracts.Models.Participant;
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

        public async Task<IReadOnlyList<ApplicationDto>> GetApplicationsAsync(Guid courseUid)
        {
            IQueryable<Application> applicationsQuery = from dbCourse in _dbContext.Courses.AsNoTracking()
                                                                                           .Where(x => x.Uid == courseUid)
                                                        join dbApplication in _dbContext.Applications.AsNoTracking()
                                                        on dbCourse.Id equals dbApplication.CourseId
                                                        select dbApplication;

            IReadOnlyList<ApplicationDto> applications = await applicationsQuery.ProjectTo<ApplicationDto>(_mapper.ConfigurationProvider)
                                                                                .ToArrayAsync();

            return applications;
        }

        public async Task<Guid> CreateApplicationAsync(Course course, DateTime courseDate, string companyName, string companyNumber,
            string companyEmail, IList<CreateParticipantRequest> participantRequests)
        {
            Application application = new ()
            {
                Uid = Guid.NewGuid(),
                CourseDate = courseDate,
                CourseName = course.Name,
                CompanyName = companyName,
                CompanyEmail = companyEmail,
                CompanyNumber = companyNumber,
                CourseId = course.Id
            };

            foreach (var item in participantRequests)
            {
                application.Participants.Add(new Participant
                {
                    Uid = Guid.NewGuid(),
                    Name = item.Name,
                    Email = item.Email,
                    Number = item.Number
                });
            }

            _dbContext.Applications.Add(application);

            await _dbContext.SaveChanges();

            return application.Uid;
        }
    }
}
