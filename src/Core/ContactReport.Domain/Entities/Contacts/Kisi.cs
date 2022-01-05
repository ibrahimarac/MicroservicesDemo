using ContactReport.Domain.Common;
using ContactReport.Domain.Entities.Contacts;
using System;
using System.Collections.Generic;

namespace ContactReport.Domain.Contacts
{
    public class Kisi:BaseEntity<Guid>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }

        public ICollection<Iletisim> IletisimBilgileri { get; set; }
    }
}
