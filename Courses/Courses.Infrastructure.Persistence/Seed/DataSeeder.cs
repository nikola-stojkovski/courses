namespace Courses.Infrastructure.Persistence.Seed
{
    using Courses.Core.Domain.Entities;
    using Courses.Infrastructure.Persistence.Context;
    using Microsoft.EntityFrameworkCore;

    public class DataSeeder : IDataSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public DataSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedData()
        {
            _dbContext.Database.Migrate();

            if (_dbContext.Courses.Any())
            {
                return;
            }

            #region Courses
            Course course1 = new()
            {
                Uid = Guid.NewGuid(),
                Name = "Cutting trees, the ins and outs.",
                Dates = new List<DateTime>()
                {
                    new DateTime(2017, 1, 1),
                    new DateTime(2017, 10, 31)
                }
            };

            Course course2 = new()
            {
                Uid = Guid.NewGuid(),
                Name = "CSS and you - a love story.",
                Dates = new List<DateTime>()
                {
                    new DateTime(2017, 5, 25),
                    new DateTime(2017, 5, 26),
                    new DateTime(2017, 5, 27)
                }
            };

            Course course3 = new()
            {
                Uid = Guid.NewGuid(),
                Name = "Baking mud cakes using actual mud.",
                Dates = new List<DateTime>()
                {
                    new DateTime(2017, 1, 1),
                    new DateTime(2018, 12, 10),
                    new DateTime(2017, 4, 1),
                    new DateTime(2019, 3, 12)
                }
            };

            Course course4 = new()
            {
                Uid = Guid.NewGuid(),
                Name = "Christmas eve - myth or reality?",
                Dates = new List<DateTime>()
                {
                    new DateTime(2017, 12, 24),
                    new DateTime(2018, 12, 24),
                    new DateTime(2019, 12, 24)
                }
            };

            Course course5 = new()
            {
                Uid = Guid.NewGuid(),
                Name = "LEGO colors through time",
                Dates = new List<DateTime>()
                {
                    new DateTime(2017, 6, 30)
                }
            };

            _dbContext.AddRange(course1, course2, course3, course4, course5);
            #endregion

            #region Applications
            Application application = new()
            {
                Uid = Guid.NewGuid(),
                Course = course1,
                CourseDate = course1.Dates[0],
                CourseName = course1.Name,
                CompanyEmail = "contact@gmail.com",
                CompanyName = "Google",
                CompanyNumber = "+38977123123",
                Participants = new List<Participant>()
                {
                    new Participant()
                    {
                        Uid = Guid.NewGuid(),
                        Name = "Nikola Stojkovski",
                        Email = "nikola@gmail.com",
                        Number = "+38978228933"
                    },
                    new Participant()
                    {
                        Uid = Guid.NewGuid(),
                        Name = "Marija Stojkovska",
                        Email = "marija@gmail.com",
                        Number = "+38977234345"
                    }
                }
            };
            _dbContext.Applications.Add(application);
            #endregion

            _dbContext.SaveChanges();
        }
    }
}
