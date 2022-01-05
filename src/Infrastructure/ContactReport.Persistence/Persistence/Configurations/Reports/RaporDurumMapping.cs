
using ContactReport.Domain.Entities.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ContactReport.Infrastructure.Persistence.Configurations.Reports
{
    public class RaporDurumMapping:BaseEntityMapping<RaporDurum,Guid>
    {
        public override void Configure(EntityTypeBuilder<RaporDurum> builder)
        {
            base.Configure(builder);

            builder.Property(rd => rd.Durum)
                .HasColumnType("varchar(50)")
                .HasColumnName("durum");

            builder.ToTable("rapor_durumlar");
        }
    }
}
