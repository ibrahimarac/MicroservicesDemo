
using Microsoft.Extensions.DependencyInjection;
using Report.Messaging.Send.Sender;

namespace Report.Messaging.Send
{
    public static class ServiceRegistiration
    {
        public static void AddRaporPersistenceServices(this IServiceCollection services)
        {
            //DbContext'i soyutlamak amacıyla kullanılan tanımlama
            services.AddTransient<IReportRequestSender, ReportRequestSender>();
        }

    }
}
