
using ContactReport.Domain.Common;

namespace ContactReport.Domain.Entities
{
    public class IletisimBilgisi:BaseEntity<string>
    {
        public string KisiId { get; set; }
        public Kisi Kisi { get; set; }

        public string BilgiTurId { get; set; }
        public IletisimBilgiTuru IletisimBilgiTuru { get; set; }

        public string BilgiIcerigi { get; set; }
    }
}
