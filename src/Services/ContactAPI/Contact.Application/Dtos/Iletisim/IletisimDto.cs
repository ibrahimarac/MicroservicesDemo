using System;

namespace Contact.Application.Dtos
{
    public class IletisimDto
    {
        public Guid IletisimId { get; set; }
        public Guid KisiId { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Konum { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
