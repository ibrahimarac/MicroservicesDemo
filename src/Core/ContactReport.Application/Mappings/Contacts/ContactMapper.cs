using AutoMapper;
using ContactReport.Application.Dtos.Contacts;
using ContactReport.Domain.Contacts;
using ContactReport.Domain.Entities.Contacts;

namespace ContactReport.Application.Mappings.Contacts
{
    public class ContactMapper:Profile
    {
        public ContactMapper()
        {
            CreateMap<Iletisim, IletisimDto>().ReverseMap();
            CreateMap<Kisi, KisiDto>();
        }
    }
}
