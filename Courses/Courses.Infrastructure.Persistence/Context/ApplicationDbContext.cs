namespace Courses.Infrastructure.Persistence.Context
{
    using Courses.Core.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        async Task<int> IApplicationDbContext.SaveChanges()
        {
            UpdateSoftDeleteStates();
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().Property(p => p.Dates)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                               v => JsonConvert.DeserializeObject<IList<DateTime>>(v));

            SetQueryFilter(modelBuilder);
        }

        private void UpdateSoftDeleteStates()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["DeletedOn"] = DateTime.Now;
                        break;

                    case EntityState.Added:
                        entry.CurrentValues["DeletedOn"] = null;
                        entry.CurrentValues["CreatedOn"] = DateTime.Now;
                        break;

                    default:
                        break;
                }
            }
        }

        private static void SetQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasQueryFilter(x => EF.Property<DateTime>(x, "DeletedOn") == null);
        }
    }
}
