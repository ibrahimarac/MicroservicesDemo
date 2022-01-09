
using Assesment.Core.Behaviors;
using Contact.Application.CommandsQueries.IletisimBilgileri.Commands.CreateIletisim;
using Contact.Application.Interfaces.Common;
using Contact.Application.Interfaces.Repositories;
using Contact.Infrastructure.Persistence;
using Contact.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Contact.CommandQuery.Tests
{
    public class DependencyInjections
    {
        private readonly ServiceCollection Services;
        protected readonly ServiceProvider ServiceProvider;

        public DependencyInjections()
        {
            Services = new ServiceCollection();

            Services.AddTransient<IContactDbContext, ContactDbContext>();
            //Posgre context
            Services.AddEntityFrameworkNpgsql()
                .AddDbContext<ContactDbContext>(
                    opt => opt.UseNpgsql("User ID=postgres;Password=123456;Server=localhost;Port=5432;Database=ContactDB;Integrated Security=true;Pooling=true"),ServiceLifetime.Transient
                );

            Services.AddTransient<IIletisimRepository, IletisimRepository>();
            Services.AddTransient<IKisiRepository, KisiRepository>();

            Services.AddAutoMapper(Assembly.GetAssembly(typeof(CreateIletisimCommandValidator)));

            Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            Services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(CreateIletisimCommandValidator)));

            Services.AddMediatR(Assembly.GetAssembly(typeof(CreateIletisimCommandValidator)));

            Services.AddLogging();

            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
