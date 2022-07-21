namespace Courses.Infrastructure.Persistence.Context
{
    using System.Threading.Tasks;
    using Courses.Core.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IApplicationDbContext
    {
        DbSet<Course> Courses { get; set; }

        DbSet<Application> Applications { get; set; }

        DbSet<Participant> Participants { get; set; }

        Task<int> SaveChanges();
    }
}
