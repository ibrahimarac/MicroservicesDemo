

using Contact.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Contact.Application.Interfaces.Repositories
{
    public interface IKisiRepository:IRepository<Kisi>
    {
        Task<Kisi> GetKisiDetail(Guid kisiId);
    }
}
