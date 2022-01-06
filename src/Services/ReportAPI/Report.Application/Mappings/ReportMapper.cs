
using AutoMapper;
using Report.Application.CommandQueries.RaporDurumIslemleri.Commands.CreateRaporDurum;
using Report.Application.Dtos;
using Report.Domain.Entities;

namespace Report.Application.Mappings
{
    public class ReportMapper:Profile
    {
        public ReportMapper()
        {
            CreateMap<Rapor, RaporDto>().ReverseMap();
            CreateMap<RaporDurum, RaporDurumDto>().ReverseMap();

            CreateMap<CreateRaporDurumCommand, RaporDurum>();
        }
    }
}
