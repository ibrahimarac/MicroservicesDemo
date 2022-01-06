
using Contact.Application.Interfaces.Repositories;
using Contact.Infrastructure.Persistence;
using Contact.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Contact.Infrastructure
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ContactDbContext>(
                    opt => opt.UseNpgsql("User ID=posgres;Password=password;Server=localhost;Port=5432;Database=ContactDB;Integrated Security=true;Pooling=true")
                );


            services.AddTransient<IKisiRepository, KisiRepository>();
            services.AddTransient<IIletisimRepository, IletisimRepository>();
        }

    }
}
