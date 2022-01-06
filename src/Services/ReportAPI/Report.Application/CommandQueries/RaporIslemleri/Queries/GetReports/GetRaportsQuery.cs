using AutoMapper;
using ContactReport.Application.Common.Exceptions;
using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
using Report.Application.Dtos;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Application.CommandQueries.RaporIslemleri.Queries.GetRaports
{
    public class GetRaportsQuery:IRequest<Response>
    {
        public Guid Id { get; set; }
    }

    public class GetRaportsQueryHandler : IRequestHandler<GetRaportsQuery, Response>
    {
        private readonly IMapper _mapper;
        private readonly IRaporRepository _raporRepository;

        public GetRaportsQueryHandler(IMapper mapper, IRaporRepository raporRepository)
        {
            _mapper = mapper;
            _raporRepository = raporRepository;
        }

        public async Task<Response> Handle(GetRaportsQuery request, CancellationToken cancellationToken)
        {
            var raporDetayEntities = await _raporRepository.GetAll();

            var raporDetayDtos = _mapper.Map<IEnumerable<Rapor>, IEnumerable<RaporDto>>(raporDetayEntities);
            return new SuccessDataResponse<IEnumerable<RaporDto>>(raporDetayDtos);
        }
    }

}
