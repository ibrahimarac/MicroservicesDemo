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
            CreateMap<KisiUpdateDto, Kisi>().ReverseMap();
            CreateMap<KisiCreateDto, Kisi>().ReverseMap();
            CreateMap<Kisi, KisiVeIletisimDto>()
                .ForMember(dto=>dto.IletisimBilgileri,m=>m.MapFrom(entity=>entity.IletisimBilgileri));
            CreateMap<CreateKisiCommand, KisiCreateDto>().ReverseMap();
            CreateMap<UpdateKisiCommand, KisiUpdateDto>().ReverseMap();

            CreateMap<Iletisim, IletisimDto>().ReverseMap();
            CreateMap<Iletisim, CreateIletisimCommand>().ReverseMap();
        }
    }
}
