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
