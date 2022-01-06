using Microsoft.EntityFrameworkCore;
using Report.Application.Interfaces.Common;
using Report.Domain.Entities;
using Report.Infrastructure.Persistence.Configurations;

namespace Report.Infrastructure.Persistence
{
    public class ReportDbContext : DbContext, IReportDbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options):base(options)
        {

        }

        public DbSet<Rapor> Raporlar { get; set; }
        public DbSet<RaporDurum> RaporDurumlar { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RaporMapping());
            modelBuilder.ApplyConfiguration(new RaporDurumMapping());

            modelBuilder.AddRaporDurumlar();
        }

        
    }
}
