using Contact.Application.Interfaces.Common;
using Contact.Application.Interfaces.Repositories;
using Contact.Domain.Entities;

namespace Contact.Infrastructure.Repositories
{
    public class KisiRepository:Repository<Kisi>,IKisiRepository
    {
        public KisiRepository(IContactDbContext context):base(context)
        {

        }
    }
}
