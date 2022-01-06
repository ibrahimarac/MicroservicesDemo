using Report.Domain.Common;
using System;
using System.Collections.Generic;

namespace Report.Domain.Entities
{
    public class RaporDurum:BaseEntity<Guid>
    {
        public string Durum { get; set; }

        public ICollection<Rapor> Raporlar { get; set; }
    }
}
