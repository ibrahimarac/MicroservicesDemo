
using AutoMapper;
using Report.Application.CommandQueries.RaporDurumIslemleri.Commands.UpdateRaporDurum;
using Report.Application.CommandQueries.RaporIslemleri.Commands.UpdateRapor;
using Report.Application.Dtos;
using Report.Domain.Entities;

namespace Report.Application.Mappings
{
    public class ReportMapper:Profile
    {
        public ReportMapper()
        {
            CreateMap<Rapor, RaporDto>().ReverseMap();

            CreateMap<Rapor, RaporDetayDto>()
                .ForMember(rd => rd.DurumId, x => x.MapFrom(r => r.RaporDurum.Id))
                .ForMember(rd => rd.Durum, x => x.MapFrom(r => r.RaporDurum.Durum));

            CreateMap<RaporDurum, RaporDurumDto>().ReverseMap();

            CreateMap<RaporUpdateDto, UpdateRaporCommand>().ReverseMap();

            CreateMap<RaporDurum, RaporDurumUpdateDto>().ReverseMap();

            CreateMap<UpdateRaporDurumCommand, RaporDurum>().ReverseMap();
        }
    }
}
