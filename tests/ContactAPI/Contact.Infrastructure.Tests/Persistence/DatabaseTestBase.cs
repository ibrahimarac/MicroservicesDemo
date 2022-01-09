using Contact.Infrastructure.Persistence;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using System;

namespace Contact.Infrastructure.Tests.Persistence
{
    public class DatabaseTestBase:IDisposable
    {
        protected readonly ContactDbContext Context;
        protected readonly DbContextOptionsBuilder<ContactDbContext> OptionsBuilder;

        public DatabaseTestBase()
        {
            OptionsBuilder = new DbContextOptionsBuilder<ContactDbContext>()
                .UseNpgsql("User ID=postgres;Password=123456;Server=localhost;Port=5432;Database=ContactDB; Integrated Security=true; Pooling=true");


            Context = new ContactDbContext(OptionsBuilder.Options);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
