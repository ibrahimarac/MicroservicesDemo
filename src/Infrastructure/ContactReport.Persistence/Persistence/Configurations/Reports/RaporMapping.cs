
using ContactReport.Domain.Entities.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ContactReport.Infrastructure.Persistence.Configurations.Reports
{
    public class RaporMapping : BaseEntityMapping<Rapor,Guid>
    {
        public override void Configure(EntityTypeBuilder<Rapor> builder)
        {
            base.Configure(builder);

            builder.Property(r => r.Path)
                .HasColumnType("varchar(150)")
                .HasColumnName("path");

            builder.Property(r => r.DurumId)
                .HasColumnName("durum_id");
            builder.HasOne(r => r.RaporDurum)
                .WithMany(rd => rd.Raporlar)
                .HasForeignKey(r => r.DurumId)
                .HasConstraintName("Rapor_Rapor_Durum_Durum_Id_Foreign_Key");

            builder.ToTable("rapor_durumlar");
        }
    }
}
