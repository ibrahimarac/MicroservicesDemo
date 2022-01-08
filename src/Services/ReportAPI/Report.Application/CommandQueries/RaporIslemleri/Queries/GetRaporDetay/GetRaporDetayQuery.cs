using Assesment.Core.Exceptions;
using Assesment.Core.Results;
using AutoMapper;
using MediatR;
using Report.Application.Dtos;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Application.CommandQueries.RaporIslemleri.Queries.GetRaporDetay
{
    public class GetRaporDetayQuery:IRequest<Response>
    {
        public Guid Id { get; set; }
    }

    public class GetRaporDetayQueryHandler : IRequestHandler<GetRaporDetayQuery, Response>
    {
        private readonly IMapper _mapper;
        private readonly IRaporRepository _raporRepository;

        public GetRaporDetayQueryHandler(IMapper mapper, IRaporRepository raporRepository)
        {
            _mapper = mapper;
            _raporRepository = raporRepository;
        }

        public async Task<Response> Handle(GetRaporDetayQuery request, CancellationToken cancellationToken)
        {
            var raporDetayEntity = await _raporRepository.GetRaporWithRaporDurumlar(request.Id);

            if (raporDetayEntity == null)
            {
                var exception = new NotFoundException(nameof(Rapor), request.Id);
                var response = new DataResponse<NotFoundException>(exception,false);
                return response;
            }

            var raporDetayDto = _mapper.Map<Rapor, RaporDetayDto>(raporDetayEntity);
            return new DataResponse<RaporDetayDto>(raporDetayDto,true);
        }
    }

}
