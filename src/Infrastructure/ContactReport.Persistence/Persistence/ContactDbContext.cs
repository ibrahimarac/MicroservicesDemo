using ContactReport.Application.Common.Interfaces;
using ContactReport.Domain.Common;
using ContactReport.Domain.Contacts;
using ContactReport.Domain.Entities.Contacts;
using ContactReport.Domain.Entities.Reports;
using ContactReport.Infrastructure.Persistence.Configurations.Contacts;
using ContactReport.Infrastructure.Persistence.Configurations.Reports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContactReport.Infrastructure.Persistence
{
    public class ContactDbContext : DbContext, IContactDbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options):base(options)
        {

        }

        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<Iletisim> IletisimBilgileri { get; set; }
        public DbSet<Rapor> Raporlar { get; set; }
        public DbSet<RaporDurum> RaporDurumlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KisiMapping());
            modelBuilder.ApplyConfiguration(new IletisimMapping());
            modelBuilder.ApplyConfiguration(new RaporDurumMapping());
            modelBuilder.ApplyConfiguration(new RaporMapping());

            modelBuilder.SeedKisiler();
            modelBuilder.SeedIletisim();
        }


        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<IAuditable>())
            {
                if(entry.Entity is IAuditable)
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateDate=DateTime.Now;
                        break;

                    case EntityState.Modified:
                            entry.Entity.LastupDate = DateTime.Now;
                        break;
                }
            }

            int result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
