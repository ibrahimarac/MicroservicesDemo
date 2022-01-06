using Contact.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Contact.Infrastructure.Persistence.Configurations.Contacts
{
    public class KisiMapping : BaseEntityMapping<Kisi, Guid>
    {
        public override void Configure(EntityTypeBuilder<Kisi> builder)
        {
            base.Configure(builder);

            builder.Property(k => k.Ad)
                .HasColumnName("ad")
                .HasColumnType("varchar(30)");

            builder.Property(k => k.Soyad)
                .HasColumnName("soyad")
                .HasColumnType("varchar(30)");

            builder.Property(k => k.Firma)
                .HasColumnName("firma")
                .HasColumnType("varchar(100)");

            builder.ToTable("kisiler");

        }
    }
}
