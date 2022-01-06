using Report.Application.Interfaces.Common;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;

namespace Contact.Infrastructure.Repositories
{
    public class RaporRepository:Repository<Rapor>,IRaporRepository
    {
        public RaporRepository(IReportDbContext context):base(context)
        {

        }
    }
}
