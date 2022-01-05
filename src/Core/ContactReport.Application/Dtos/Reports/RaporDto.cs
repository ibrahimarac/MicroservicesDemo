using System;

namespace ContactReport.Application.Dtos.Reports
{
    public class RaporDto
    {
        public Guid Id { get; set; }
        public int DurumId { get; set; }
        public string Durum { get; set; }
        public string Path { get; set; }
    }
}
