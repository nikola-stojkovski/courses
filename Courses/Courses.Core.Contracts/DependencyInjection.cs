namespace Courses.Core.Contracts
{
    using System;
    using Courses.Core.Contracts.Settings;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static void AddContracts(this IServiceCollection services)
        {
            services.AddSingleton<IAppSettings, AppSettings>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
