
using Assesment.Core.Behaviors;
using Contact.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Report.Application.CommandQueries.RaporDurumIslemleri.Commands.CreateRaporDurum;
using Report.Application.Interfaces.Common;
using Report.Application.Interfaces.Repositories;
using Report.Infrastructure.Persistence;
using System.Reflection;

namespace Report.CommandQuery.Tests
{
    public class DependencyInjections
    {
        private readonly ServiceCollection Services;
        protected readonly ServiceProvider ServiceProvider;

        public DependencyInjections()
        {
            Services = new ServiceCollection();

            Services.AddTransient<IReportDbContext, ReportDbContext>();
            //Posgre context
            Services.AddEntityFrameworkNpgsql()
                .AddDbContext<ReportDbContext>(
                    opt => opt.UseNpgsql("User ID=postgres;Password=123456;Server=localhost;Port=5432;Database=ReportDB;Integrated Security=true;Pooling=true"),ServiceLifetime.Transient
                );

            var asm = Assembly.GetAssembly(typeof(CreateRaporDurumCommandHandler));

            Services.AddTransient<IRaporDurumRepository, RaporDurumRepository>();
            Services.AddTransient<IRaporRepository, RaporRepository>();

            Services.AddAutoMapper(asm);

            Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            Services.AddValidatorsFromAssembly(asm);

            Services.AddMediatR(asm);

            Services.AddLogging();

            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
