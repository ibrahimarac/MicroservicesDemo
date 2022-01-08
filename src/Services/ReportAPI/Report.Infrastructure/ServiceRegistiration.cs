using Contact.Infrastructure.Repositories;
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
        public static void AddRaporPersistenceServices(this IServiceCollection services)
        {
            //Posgre context
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ReportDbContext>(
                    opt => opt.UseNpgsql("User ID=postgres;Password=123456;Server=localhost;Port=5432;Database=ReportDB;Integrated Security=true;Pooling=true"),
                    ServiceLifetime.Scoped
                );

            //DbContext'i soyutlamak amacıyla kullanılan tanımlama
            services.AddScoped<IReportDbContext, ReportDbContext>();

            //Excel dosyası üretmek için kullanılacak servisimiz
            services.AddTransient<IExcelFileBuilder, ExcelFileBuilder>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRaporRepository, RaporRepository>();
            services.AddScoped<IRaporDurumRepository, RaporDurumRepository>();
        }

    }
}
