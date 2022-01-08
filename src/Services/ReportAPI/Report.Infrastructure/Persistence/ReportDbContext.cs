using Microsoft.EntityFrameworkCore;
using Report.Application.Interfaces.Common;
using Report.Domain.Common;
using Report.Domain.Entities;
using Report.Infrastructure.Persistence.Configurations;
using System;
using System.Threading;
using System.Threading.Tasks;

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


        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess = true, CancellationToken cancellationToken = default)
        {
            int result = 0;

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is IAuditable)
                {
                    var auditableEntity = entry.Entity as IAuditable;
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditableEntity.CreateDate = DateTime.Now;
                            break;

                        case EntityState.Modified:
                            auditableEntity.LastupDate = DateTime.Now;
                            break;
                    }
                }
            }

            if (!cancellationToken.IsCancellationRequested)
                await Task.FromResult(base.SaveChanges());

            return result;
        }


    }
}
