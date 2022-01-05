
using System;

namespace ContactReport.Application.Dtos.Contacts
{
    public class KisiDto
    {
        public Guid Id  { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
