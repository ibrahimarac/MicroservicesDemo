using Core.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application
{
    public static class ServiceRegistiration
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        }

    }
}
