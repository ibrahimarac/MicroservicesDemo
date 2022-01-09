using Contact.Application.Interfaces.Common;
using Contact.Application.Interfaces.Repositories;
using Contact.Infrastructure.Persistence;
using Contact.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Contact.Application
{
    public static class ServiceRegistiration
    {
        public static void AddContactPersistenceServices(this IServiceCollection services)
        {            
            //Posgre context
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ContactDbContext>(
                    opt => opt.UseNpgsql("User ID=postgres;Password=123456;Server=localhost;Port=5432;Database=ContactDB;Integrated Security=true;Pooling=true"),ServiceLifetime.Transient
                );

            services.AddTransient<IContactDbContext, ContactDbContext>();

            //repositories
            services.AddTransient<IKisiRepository, KisiRepository>();
            services.AddTransient<IIletisimRepository, IletisimRepository>();            
        }

    }
}
