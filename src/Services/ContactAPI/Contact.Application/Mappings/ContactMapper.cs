using AutoMapper;
using Contact.Application.CommandsQueries.IletisimBilgileri.Commands.CreateIletisim;
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
            CreateMap<Kisi, KisiDto>().ReverseMap();
            CreateMap<UpdateKisiDto, Kisi>();
            CreateMap<Kisi, KisiVeIletisimDto>()
                .ForMember(dto=>dto.IletisimBilgileri,m=>m.MapFrom(entity=>entity.IletisimBilgileri));
            CreateMap<CreateKisiCommand, Kisi>().ReverseMap();
            CreateMap<UpdateKisiCommand, Kisi>().ReverseMap();

            CreateMap<Iletisim, IletisimDto>().ReverseMap();
            CreateMap<IletisimDto, CreateIletisimCommand>().ReverseMap();
        }
    }
}
