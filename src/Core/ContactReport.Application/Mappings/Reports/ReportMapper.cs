
using AutoMapper;
using ContactReport.Application.Dtos.Reports;
using ContactReport.Domain.Entities.Reports;

namespace ContactReport.Application.Mappings.Reports
{
    public class ReportMapper:Profile
    {
        public ReportMapper()
        {
            CreateMap<Rapor, RaporDto>().ReverseMap();
            CreateMap<RaporDurum, RaporDurumDto>().ReverseMap();
        }
    }
}
