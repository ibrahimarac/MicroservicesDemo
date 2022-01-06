using Microsoft.EntityFrameworkCore;
using Report.Application.Interfaces.Common;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;
using Report.Infrastructure.Persistence;
using System;
using System.Linq;

namespace Contact.Infrastructure.Repositories
{
    public class RaporRepository:Repository<Rapor>,IRaporRepository
    {
        public RaporRepository(IReportDbContext context):base(context)
        {

        }

        public Rapor GetRaporWithRaporDurumlar(Guid id)
        {
            var context = Context as ReportDbContext;
            return context.Raporlar.Include(r => r.RaporDurum)
                .SingleOrDefault();
        }
    }
}
