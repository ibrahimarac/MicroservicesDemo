using System;

namespace Report.Application.Dtos
{
    public class RaporDto
    {
        public Guid Id { get; set; }
        public int DurumId { get; set; }
        public string Durum { get; set; }
        public string Path { get; set; }
    }
}
