
using Microsoft.EntityFrameworkCore;
using Report.Domain.Entities;
using Report.Infrastructure.Persistence;
using Report.Infrastructure.Tests.Repository;
using System;
using System.Reflection;
using Xunit.Sdk;

namespace Report.Infrastructure.Tests.Persistence
{
    public class DatabaseTestBase:  IDisposable
    {
        protected readonly ReportDbContext Context;
        protected readonly DbContextOptionsBuilder<ReportDbContext> OptionsBuilder;

        public DatabaseTestBase()
        {
            OptionsBuilder = new DbContextOptionsBuilder<ReportDbContext>()
                .UseNpgsql("User ID=postgres;Password=123456;Server=localhost;Port=5432;Database=ReportDB; Integrated Security=true; Pooling=true");

            Context = new ReportDbContext(OptionsBuilder.Options);

        }

        

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
