namespace Courses.Core.Application
{
    using System.Reflection;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using FluentValidation;
    using Courses.Core.Application.Behaviours;

    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
