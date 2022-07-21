namespace Courses.Infrastructure.Persistence
{
    using Courses.Core.Contracts.Interfaces;
    using Courses.Core.Contracts.Settings;
    using Courses.Infrastructure.Persistence.Context;
    using Courses.Infrastructure.Persistence.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            IAppSettings appSettings = new AppSettings(configuration);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    appSettings.ConnectionStrings.DefaultConnection,
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddScoped<ICoursesRepository, CoursesRepository>();
            services.AddScoped<IApplicationsRepository, ApplicationsRepository>();
        }
    }
}
