using Contact.Domain.Common;
using System;
using System.Collections.Generic;

namespace Contact.Domain.Entities
{
    public class Kisi:BaseEntity<Guid>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }

        public ICollection<Iletisim> IletisimBilgileri { get; set; }
    }
}
