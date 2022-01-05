using System;
using System.Collections.Generic;

namespace ContactReport.Application.Dtos.Contacts
{
    public class KisiVeIletisimDto
    {
        public Guid KisiId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        public IEnumerable<IletisimDto> IletisimBilgileri { get; set; }
    }
}
