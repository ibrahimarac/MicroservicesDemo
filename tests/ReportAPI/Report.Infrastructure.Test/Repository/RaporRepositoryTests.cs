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
    public class RaporRepositoryTests : DatabaseTestBase
    {
        private readonly RaporRepository _testee;
        private readonly Rapor _newRapor;

        public RaporRepositoryTests()
        {
            _testee = new RaporRepository(Context);
            _newRapor = new Rapor
            {
                CreateDate = DateTime.Now,
                LastupDate = DateTime.Now,
                DurumId = Context.RaporDurumlar.Single(rd => rd.Durum == "HAZIRLANIYOR").Id
            };
        }

        [Fact]
        public async void CreateRaporAsync_WhenRaporIsNotNull_ShouldShouldAddRapor()
        {
            var raporCount = Context.Raporlar.Count();

            _newRapor.Id = Guid.NewGuid();

            var result = await _testee.Add(_newRapor);

            result.Should().BeOfType<Rapor>();

            Context.Raporlar.Count().Should().Be(raporCount + 1);
        }


        [Theory]
        [InlineData("Güncellenen Path")]
        public async void UpdateRaporAsync_WhenRaporIsNotNull_ShouldReturnRapor(string path)
        {
            //son eklenen raporu bul
            var rapor = Context.Raporlar.OrderByDescending(r => r.CreateDate).First();

            rapor.Path = path;
            rapor.DurumId = Context.RaporDurumlar.First().Id;

            await _testee.Update(rapor);

            rapor.Should().BeOfType<Rapor>();
            rapor.Path.Should().Be(path);
            rapor.DurumId.Should().Be(rapor.DurumId);
        }


    }
}
