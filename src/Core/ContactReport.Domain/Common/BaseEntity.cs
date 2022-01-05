
using System;

namespace ContactReport.Domain.Common
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
