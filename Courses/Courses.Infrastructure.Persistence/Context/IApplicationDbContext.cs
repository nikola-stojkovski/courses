namespace Courses.Infrastructure.Persistence.Context
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Courses.Core.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IApplicationDbContext
    {
        DbSet<Course> Courses { get; set; }

        Task<int> SaveChanges();
    }
}
