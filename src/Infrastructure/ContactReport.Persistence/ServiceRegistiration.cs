
using ContactReport.Application.Common.Interfaces;
using ContactReport.Infrastructure.Persistence;
using ContactReport.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ContactReport.Infrastructure
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ContactDbContext>(
                    opt => opt.UseNpgsql("User ID=posgres;Password=password;Server=localhost;Port=5432;Database=ContactDB;Integrated Security=true;Pooling=true")
                );

            services.AddTransient<IExcelFileBuilder, ExcelFileBuilder>();
        }

    }
}
