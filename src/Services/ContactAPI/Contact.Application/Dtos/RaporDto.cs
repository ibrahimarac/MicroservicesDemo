
using MediatR;

namespace Contact.Application.Dtos
{
    public class RaporDto:INotification
    {
        public string Konum { get; set; }
        public int KisiSayisi { get; set; }
        public int TelnoSayisi { get; set; }
    }
}
