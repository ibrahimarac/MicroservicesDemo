using Microsoft.EntityFrameworkCore;
using Report.Domain.Entities;
using System.Threading.Tasks;

namespace Report.Application.Interfaces.Common
{
    public interface IReportDbContext
    {
        public DbSet<Rapor> Raporlar { get; set; }
        public DbSet<RaporDurum> RaporDurumlar { get; set; }
    }
}
