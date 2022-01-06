using Microsoft.EntityFrameworkCore;
using Report.Domain.Entities;
using System;

namespace Report.Infrastructure.Persistence
{
    public static class ReportDbContextSeeder
    {
        public static void AddRaporDurumlar(this ModelBuilder builder)
        {
            builder.Entity<RaporDurum>()
                .HasData(
                    new RaporDurum
                    {
                        Id=new Guid("54a0bfc0-d88d-4e75-a067-9547e977c926"),
                        Durum="HAZIRLANIYOR"
                    },
                    new RaporDurum
                    {
                        Id = new Guid("2143a48a-7190-4ee0-a894-743733ac09b9"),
                        Durum = "TAMAMLANDI"
                    }
                );
        }
    }
}
