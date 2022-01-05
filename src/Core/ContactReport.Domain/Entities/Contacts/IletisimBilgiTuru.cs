using ContactReport.Domain.Common;
using System;

namespace ContactReport.Domain.Contacts
{
    public class IletisimBilgiTuru:BaseEntity<Guid>
    {
        public string TurAdi { get; set; }
    }
}
