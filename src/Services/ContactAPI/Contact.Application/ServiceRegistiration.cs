using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Contact.Infrastructure
{
    public static class ServiceRegistiration
    {
        public static void AddContactApplicationServices(this IServiceCollection services)
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
