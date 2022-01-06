using AutoMapper;
using ContactReport.Application.Dtos.Contacts;
using ContactReport.Domain.Contacts;
using ContactReport.Domain.Entities.Contacts;

namespace Contact.Application.Mappings
{
    public class ContactMapper:Profile
    {
        public ContactMapper()
        {
            CreateMap<Iletisim, IletisimDto>().ReverseMap();
            CreateMap<Kisi, KisiDto>().ReverseMap();
        }
    }
}
