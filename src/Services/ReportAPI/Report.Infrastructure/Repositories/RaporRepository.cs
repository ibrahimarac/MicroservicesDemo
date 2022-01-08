using Microsoft.EntityFrameworkCore;
using Report.Application.Interfaces.Common;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;
using Report.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Repositories
{
    public class RaporRepository:Repository<Rapor>,IRaporRepository
    {
        public RaporRepository(IReportDbContext context):base(context)
        {

        }

        public async Task<Rapor> GetRaporWithRaporDurumlar(Guid id)
        {
            var context = Context as ReportDbContext;
            return await context.Raporlar.Include(r => r.RaporDurum)
                .SingleOrDefaultAsync(r=>r.Id==id);
        }

        public async Task<IEnumerable<Rapor>> GetRaporlarWithRaporDurumlar()
        {
            var context = Context as ReportDbContext;
            return await context.Raporlar.Include(r => r.RaporDurum)
                .ToListAsync();
        }

    }
}
