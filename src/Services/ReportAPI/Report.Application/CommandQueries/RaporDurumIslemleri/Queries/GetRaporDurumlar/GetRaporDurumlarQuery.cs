using AutoMapper;
using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
using Report.Application.Dtos;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Application.CommandQueries.RaporDurumIslemleri.Queries.GetRaporDurumlar
{
    public class GetRaporDurumlarQuery:IRequest<Response>
    {

    }

    public class GetRaporDurumlarQueryHandler : IRequestHandler<GetRaporDurumlarQuery, Response>
    {
        private readonly IRaporDurumRepository _raporDurumRepository;
        private readonly IMapper _mapper;

        public GetRaporDurumlarQueryHandler(IRaporDurumRepository raporDurumRepository,IMapper mapper)
        {
            _raporDurumRepository = raporDurumRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetRaporDurumlarQuery request, CancellationToken cancellationToken)
        {
            var raporDurumlar = await _raporDurumRepository.GetAll();
            var raporDurumlarDto = _mapper.Map<IEnumerable<RaporDurum>, IEnumerable<RaporDurumDto>>(raporDurumlar);

            return new SuccessDataResponse<IEnumerable<RaporDurumDto>>(raporDurumlarDto);
        }
    }

}
