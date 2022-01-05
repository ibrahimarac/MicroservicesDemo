using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ContactReport.Application
{
    public static class ServiceRegistiration
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
