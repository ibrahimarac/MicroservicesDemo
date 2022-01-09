using Contact.Domain.Entities;
using Contact.Infrastructure.Repositories;
using Contact.Infrastructure.Tests.Persistence;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Contact.Infrastructure.Tests.Repository
{
    public class IletisimRepositoryTests : DatabaseTestBase
    {
        private readonly IletisimRepository _testee;
        private readonly Iletisim _newIletisim;

        public IletisimRepositoryTests()
        {
            _testee = new IletisimRepository(Context);
            _newIletisim = new Iletisim
            {
                Email = "ibrahimarac.mct@gmail.com",
                Konum = "BOLU",
                Telefon = "(505)9999999",
                KisiId = Context.Kisiler.First().Id
            };
        }

        [Fact]
        public async void CreateIletisimAsync_WhenIletisimIsNotNull_ShouldShouldAddIletisim()
        {
            var iletisimCount = Context.IletisimBilgileri.Count();

            _newIletisim.Id = Guid.NewGuid();

            var result = await _testee.Add(_newIletisim);

            result.Should().BeOfType<Iletisim>();

            Context.IletisimBilgileri.Count().Should().Be(iletisimCount + 1);
        }

        [Theory]
        [InlineData("Yeni Konum","Yeni eposta")]
        public async void UpdateIletisimAsync_WhenIletisimIsNotNull_ShouldReturnIletisim(string konum,string email)
        {
            var iletisim = Context.IletisimBilgileri.OrderByDescending(i => i.CreateDate).First();

            iletisim.Konum = konum;
            iletisim.Email = email;

            await _testee.Update(iletisim);

            iletisim.Should().BeOfType<Iletisim>();
            iletisim.Konum.Should().Be(konum);
            iletisim.Email.Should().Be(email);
        }


        [Fact]
        public async void DeleteIletisimAsync_WhenIletisimIsNotNull_ShouldShouldDeleteIletisim()
        {
            var iletisimCount = Context.IletisimBilgileri.Count();

            var iletisim = Context.IletisimBilgileri.OrderByDescending(i => i.CreateDate).First();

            await _testee.Delete(iletisim.Id);

            Context.IletisimBilgileri.Count().Should().Be(iletisimCount - 1);
        }

    }
}
