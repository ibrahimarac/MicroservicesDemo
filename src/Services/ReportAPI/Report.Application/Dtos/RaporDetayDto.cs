using System;

namespace Report.Application.Dtos
{
    public class RaporDetayDto
    {
        public Guid Id { get; set; }
        public Guid DurumId { get; set; }
        public string Durum { get; set; }
        public string Path { get; set; }
    }
}
