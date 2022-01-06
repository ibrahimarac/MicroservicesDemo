using System;
using System.Collections.Generic;

namespace Contact.Application.Dtos
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
