using ContactReport.Domain.Common;

namespace ContactReport.Domain.Entities
{
    public class IletisimBilgiTuru:BaseEntity<string>
    {
        public string TurAdi { get; set; }
    }
}
