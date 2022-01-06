using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Report.Application.Interfaces.Common;
using Report.Application.Interfaces.Repositories;
using Report.Infrastructure.Persistence;
using Report.Infrastructure.Services;

namespace Report.Infrastructure
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ReportDbContext>(
                    opt => opt.UseNpgsql("User ID=posgres; Password=password; Server=localhost;Port=5432;Database=RaporDB;Integrated Security=true;Pooling=true")
                );

            services.AddTransient<IExcelFileBuilder, ExcelFileBuilder>();

            services.AddTransient<IRaporRepository, IRaporRepository>();
            services.AddTransient<IRaporDurumRepository, IRaporDurumRepository>();
        }

    }
}
