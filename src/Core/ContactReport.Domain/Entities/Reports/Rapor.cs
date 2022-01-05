
using ContactReport.Domain.Common;
using System;

namespace ContactReport.Domain.Entities.Reports
{
    public class Rapor:BaseEntity<Guid>
    {
        public RaporDurum RaporDurum { get; set; }
        public int DurumId { get; set; }
    }
}
