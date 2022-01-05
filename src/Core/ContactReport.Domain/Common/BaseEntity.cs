﻿
using System;

namespace ContactReport.Domain.Common
{
    public class BaseEntity<T>:IAuditable
    {
        public T Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastupDate { get; set; }
    }
}
