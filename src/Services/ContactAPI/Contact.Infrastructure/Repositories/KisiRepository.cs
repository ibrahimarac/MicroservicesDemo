using Contact.Application.Interfaces.Common;
using Contact.Application.Interfaces.Repositories;
using Contact.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Repositories
{
    public class KisiRepository:Repository<Kisi>,IKisiRepository
    {
        public KisiRepository(IContactDbContext context):base(context)
        {

        }

        public async Task<Kisi> GetKisiDetail(Guid kisiId)
        {
            return await (Context as IContactDbContext).Kisiler.Include(k => k.IletisimBilgileri)
                .SingleOrDefaultAsync(k => k.Id == kisiId);
        }
    }
}
