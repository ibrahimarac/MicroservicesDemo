using Contact.Domain.Entities;
using Contact.Infrastructure.Persistence;
using Contact.Infrastructure.Repositories;
using Contact.Infrastructure.Tests.Persistence;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Contact.Infrastructure.Tests.Repository
{
    public class KisiRepositoryTests:DatabaseTestBase
    {
        private readonly KisiRepository _testee;
        private readonly Kisi _newContact;

        public KisiRepositoryTests()
        {
            _testee = new KisiRepository(Context);
            _newContact  = new Kisi
            {
                Ad = "İbrahim",
                Soyad="ARAÇ",
                CreateDate=DateTime.Now,
                Firma="Firma x",
                LastupDate=DateTime.Now
            };
        }

        [Fact]
        public async void CreateKisiAsync_WhenKisiIsNotNull_ShouldShouldAddKisi()
        {
            var kisiCount = Context.Kisiler.Count();

            _newContact.Id = Guid.NewGuid();
            
            var result=await _testee.Add(_newContact);

            result.Should().BeOfType<Kisi>();

            Context.Kisiler.Count().Should().Be(kisiCount + 1);
        }

        [Theory]
        [InlineData("YeniAd")]
        public async void UpdateKisiAsync_WhenKisiIsNotNull_ShouldReturnKisi(string ad)
        {
            var kisi = await Context.Kisiler.OrderByDescending(k => k.CreateDate).FirstAsync();

            kisi.Ad = ad;

            await _testee.Update(kisi);

            kisi.Should().BeOfType<Kisi>();
            kisi.Ad.Should().Be(ad);
        }


    }
}
