using Contact.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Contact.Infrastructure.Persistence.Configurations.Contacts
{
    public class IletisimMapping : BaseEntityMapping<Iletisim, Guid>
    {
        public override void Configure(EntityTypeBuilder<Iletisim> builder)
        {
            base.Configure(builder);

            builder.Property(k => k.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(150)");

            builder.Property(k => k.KisiId)
                .HasColumnName("kisi_id");

            //relation
            builder.HasOne(i => i.Kisi)
                .WithMany(k => k.IletisimBilgileri)
                .HasForeignKey(k => k.KisiId)
                .HasConstraintName("Iletisim_Bilgileri_Kisi_KisiId_Foreign_Key");

            builder.Property(k => k.Konum)
                .HasColumnName("konum")
                .HasColumnType("varchar(30)");

                builder.Property(k => k.Telefon)
                .HasColumnName("konum")
                .HasColumnType("varchar(14)");

            builder.ToTable("iletisim_bilgileri");
        }
    }
}
