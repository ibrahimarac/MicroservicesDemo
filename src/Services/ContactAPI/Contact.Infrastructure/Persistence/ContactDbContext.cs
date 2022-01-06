using Contact.Application.Interfaces.Common;
using Contact.Domain.Common;
using Contact.Domain.Entities;
using Contact.Infrastructure.Persistence.Configurations.Contacts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Persistence
{
    public class ContactDbContext : DbContext, IContactDbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options):base(options)
        {

        }

        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<Iletisim> IletisimBilgileri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KisiMapping());
            modelBuilder.ApplyConfiguration(new IletisimMapping());

            modelBuilder.SeedKisiler();
            modelBuilder.SeedIletisim();
        }

        

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess=true, CancellationToken cancellationToken = default)
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
