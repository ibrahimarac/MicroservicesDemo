
using Contact.Application.Interfaces.Common;
using Contact.Application.Interfaces.Repositories;
using Contact.Domain.Entities;

namespace Contact.Infrastructure.Repositories
{
    public class IletisimRepository:Repository<Iletisim>,IIletisimRepository
    {
        public IletisimRepository(IContactDbContext context):base(context)
        {

        }
    }
}
