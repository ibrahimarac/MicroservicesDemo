
using ContactReport.Domain.Contacts;
using ContactReport.Domain.Entities.Contacts;
using ContactReport.Domain.Entities.Reports;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ContactReport.Application.Common.Interfaces
{
    public interface IContactDbContext
    {
        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<Iletisim> IletisimBilgileri { get; set; }
        public DbSet<Rapor> Raporlar { get; set; }
        public DbSet<RaporDurum> RaporDurumlar { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
