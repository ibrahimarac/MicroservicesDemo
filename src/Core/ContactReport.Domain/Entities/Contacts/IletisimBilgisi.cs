
using ContactReport.Domain.Common;
using System;

namespace ContactReport.Domain.Entities.Contacts
{
    public class IletisimBilgisi:BaseEntity<Guid>
    {
        public Guid KisiId { get; set; }
        public Kisi Kisi { get; set; }

        public Guid BilgiTurId { get; set; }
        public IletisimBilgiTuru IletisimBilgiTuru { get; set; }

        public string BilgiIcerigi { get; set; }

    }
}
