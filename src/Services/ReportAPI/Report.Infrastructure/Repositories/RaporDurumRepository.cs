using Report.Application.Interfaces.Common;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;

namespace Contact.Infrastructure.Repositories
{
    public class RaporDurumRepository : Repository<RaporDurum>,IRaporDurumRepository
    {
        public RaporDurumRepository(IReportDbContext context):base(context)
        {

        }
    }
}
