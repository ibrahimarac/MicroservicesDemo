
using Contact.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Interfaces.Common
{
    public interface IContactDbContext
    {
        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<Iletisim> IletisimBilgileri { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
