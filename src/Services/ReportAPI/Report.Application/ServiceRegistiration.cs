using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Report.Application
{
    public static class ServiceRegistiration
    {
        public static void AddRaporApplicationServices(this IServiceCollection services)
        {
            var asm = Assembly.GetExecutingAssembly();

            //automapper
            services.AddAutoMapper(asm);
            //fluent validation
            services.AddValidatorsFromAssembly(asm);

            //CQRS
            services.AddMediatR(asm);


            
        }

    }
}
