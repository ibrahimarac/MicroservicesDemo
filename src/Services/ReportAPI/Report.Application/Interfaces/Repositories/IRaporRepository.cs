

using Report.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Report.Application.Interfaces.Repositories
{
    public interface IRaporRepository:IRepository<Rapor>
    {
        Task<Rapor> GetRaporWithRaporDurumlar(Guid id);
    }
}
