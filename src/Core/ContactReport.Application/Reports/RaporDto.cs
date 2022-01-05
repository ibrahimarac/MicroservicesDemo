using System;
using System.Collections.Generic;
using System.Text;

namespace ContactReport.Application.Reports
{
    public class RaporDto
    {
        public Guid Id { get; set; }
        public int DurumId { get; set; }
        public string Durum { get; set; }
    }
}
