using Report.Domain.Common;
using System;

namespace Report.Domain.Entities
{
    public class Rapor:BaseEntity<Guid>
    {
        public RaporDurum RaporDurum { get; set; }
        public Guid DurumId { get; set; }

        public string Path { get; set; }
    }
}
