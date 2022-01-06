using System;

namespace Contact.Domain.Common
{
    public interface IAuditable
    {
        public DateTime CreateDate { get; set; }
        public DateTime LastupDate { get; set; }
    }
}
