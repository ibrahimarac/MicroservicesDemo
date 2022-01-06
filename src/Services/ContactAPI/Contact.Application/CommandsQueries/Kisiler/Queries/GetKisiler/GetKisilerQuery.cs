using AutoMapper;
using Contact.Application.Dtos;
using Contact.Application.Interfaces.Repositories;
using Contact.Domain.Entities;
using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.CommandsQueries.Kisiler.Queries.GetKisiler
{
    public class GetKisilerQuery : IRequest<Response>
    {

    }

    public class GetKisilerQueryHandler : IRequestHandler<GetKisilerQuery, Response>
    {
        private readonly IKisiRepository _kisiRepository;
        private readonly IMapper _mapper;

        public GetKisilerQueryHandler(IKisiRepository kisiRepository, IMapper mapper)
        {
            _kisiRepository = kisiRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetKisilerQuery request, CancellationToken cancellationToken)
        {
            var kisiler =await _kisiRepository.GetAll();
            var kisilerDto = _mapper.Map<IEnumerable<Kisi>, IEnumerable<KisiDto>>(kisiler);
            return new SuccessDataResponse<IEnumerable<KisiDto>>(kisilerDto);
        }
    }
}
