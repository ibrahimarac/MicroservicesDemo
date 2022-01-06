

using Report.Domain.Entities;
using System;

namespace Report.Application.Interfaces.Repositories
{
    public interface IRaporRepository:IRepository<Rapor>
    {
        Rapor GetRaporWithRaporDurumlar(Guid id);
    }
}
