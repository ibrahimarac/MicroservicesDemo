using AutoMapper;
using Contact.Application.CommandsQueries.Kisiler.Commands.CreateKisi;
using Contact.Application.CommandsQueries.Kisiler.Commands.UpdateKisi;
using Contact.Application.Dtos;
using Contact.Domain.Entities;

namespace Contact.Application.Mappings
{
    public class ContactMapper:Profile
    {
        public ContactMapper()
        {
            CreateMap<Iletisim, IletisimDto>().ReverseMap();
            CreateMap<Kisi, KisiDto>().ReverseMap();

            CreateMap<Kisi, KisiVeIletisimDto>()
                .ForMember(dto=>dto.IletisimBilgileri,m=>m.MapFrom(entity=>entity.IletisimBilgileri));

            CreateMap<CreateKisiCommand, Kisi>().ReverseMap();
            CreateMap<UpdateKisiCommand, Kisi>().ReverseMap();
        }
    }
}
