using System;
using System.Collections.Generic;

namespace ContactReport.Application.Contacts
{
    public class KisiVeIletisimDto
    {
        public Guid KisiId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        public IEnumerable<Iletisim> IletisimBilgileri { get; set; }
    }

    public class Iletisim
    {
        public Guid IletisimId { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Konum { get; set; }
    }
}
