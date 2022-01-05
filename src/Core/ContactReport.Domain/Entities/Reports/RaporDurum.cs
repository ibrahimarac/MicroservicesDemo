using ContactReport.Domain.Common;
using System;
using System.Collections.Generic;

namespace ContactReport.Domain.Entities.Reports
{
    public class RaporDurum:BaseEntity<Guid>
    {
        public string Durum { get; set; }

        public ICollection<Rapor> Raporlar { get; set; }
    }
}
