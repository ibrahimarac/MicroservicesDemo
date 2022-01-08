using FluentValidation;
using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Report.Application.CommandQueries.RaporDurumIslemleri.Commands.CreateRaporDurum;
using Report.Application.CommandQueries.RaporIslemleri.Commands.UpdateRapor;
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
