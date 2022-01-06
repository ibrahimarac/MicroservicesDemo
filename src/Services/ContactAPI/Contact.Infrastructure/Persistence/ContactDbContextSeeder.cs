
using ContactReport.Domain.Contacts;
using ContactReport.Domain.Entities.Contacts;
using Microsoft.EntityFrameworkCore;
using System;

namespace Contact.Infrastructure.Persistence
{
    public static class ContactDbContextSeeder
    {
        public static void SeedKisiler(this ModelBuilder builder)
        {
            builder.Entity<Kisi>()
                .HasData(
                    new Kisi
                    {
                        Id = new Guid("27714296-cbce-4ad3-a8fa-4980ac44987c"),
                        Ad = "ad1",
                        Soyad = "soyad1",
                        CreateDate = DateTime.Now,
                        Firma = "firma1"
                    },
                    new Kisi
                    {
                        Id = new Guid("3acf9782-999a-4364-aee6-c692f9d4ad4f"),
                        Ad = "ad2",
                        Soyad = "soyad2",
                        CreateDate = DateTime.Now,
                        Firma = "firma2"
                    }
                );
        }

        public static void SeedIletisim(this ModelBuilder builder)
        {
            builder.Entity<Iletisim>()
            .HasData(
                new Iletisim
                {
                    Id = new Guid("1b85d9b8-7b7c-4efc-893e-45045c50d282"),
                    Email = "kisi1@gmail.com",
                    Konum = "ANKARA",
                    Telefon = "(505)999 99 99",
                    KisiId = new Guid("27714296-cbce-4ad3-a8fa-4980ac44987c")
                },
                new Iletisim
                {
                    Id = new Guid("072593f9-cde8-4e75-a20a-c1e923580ae0"),
                    Email = "kisi2@gmail.com",
                    Konum = "İSTANBUL",
                    Telefon = "(505)555 55 55",
                    KisiId = new Guid("3acf9782-999a-4364-aee6-c692f9d4ad4f")
                }
            );
        }

    }
}
}
