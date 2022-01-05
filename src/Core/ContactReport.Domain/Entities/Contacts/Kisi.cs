using ContactReport.Domain.Common;
using System;

namespace ContactReport.Domain.Contacts
{
    public class Kisi:BaseEntity<Guid>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }

    }
}
