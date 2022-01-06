using Contact.Domain.Common;
using System;

namespace Contact.Domain.Entities
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
