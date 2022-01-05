
using ContactReport.Domain.Common;
using ContactReport.Domain.Contacts;
using System;

namespace ContactReport.Domain.Entities.Contacts
{
    public class Iletisim:BaseEntity<Guid>
    {
        public Guid KisiId { get; set; }
        public Kisi Kisi { get; set; }

        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Konum { get; set; }

    }
}
