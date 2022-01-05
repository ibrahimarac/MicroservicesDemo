using ContactReport.Domain.Common;

namespace ContactReport.Domain.Entities
{
    public class Kisi:BaseEntity<string>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }

    }
}
