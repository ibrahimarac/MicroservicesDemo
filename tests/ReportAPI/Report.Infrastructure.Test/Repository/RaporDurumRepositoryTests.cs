using Contact.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Report.Domain.Entities;
using Report.Infrastructure.Tests.Persistence;
using System;
using System.Linq;
using Xunit;

namespace Report.Infrastructure.Tests.Repository
{
    public class RaporDurumRepositoryTests:DatabaseTestBase
    {
        private readonly RaporDurumRepository _testee;

        public RaporDurumRepositoryTests()
        {
            _testee = new RaporDurumRepository(Context);
        }


        [Theory]
        [InlineData("Yeni Durum")]
        public async void CreateRaporDurumAsync_WhenRaporDurumIsNotNull_ShouldShouldAddRaporDurum(string durum)
        {
            var raporDurumCount = Context.RaporDurumlar.Count();

            var raporDurum = new RaporDurum
            {
                Id = Guid.NewGuid(),
                Durum = durum
            };
            
            var result=await _testee.Add(raporDurum);

            result.Should().BeOfType<RaporDurum>();

            Context.RaporDurumlar.Count().Should().Be(raporDurumCount + 1);
        }

        [Theory]
        [InlineData("Güncellenen Durum")]
        public async void UpdateRaporDurumAsync_WhenRaporDurumIsNotNull_ShouldReturnRaporDurum(string durum)
        {
            var raporDurum = Context.RaporDurumlar.OrderByDescending(rd => rd.CreateDate).First();

            raporDurum.Durum = durum;

            await _testee.Update(raporDurum);

            raporDurum.Should().BeOfType<RaporDurum>();
            raporDurum.Durum.Should().Be(durum);
        }

    }
}
