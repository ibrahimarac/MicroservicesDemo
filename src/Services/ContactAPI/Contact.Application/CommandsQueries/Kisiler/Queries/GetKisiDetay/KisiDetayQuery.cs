using Assesment.Core.Exceptions;
using Assesment.Core.Results;
using AutoMapper;
using Contact.Application.Dtos;
using Contact.Application.Interfaces.Repositories;
using Contact.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.CommandsQueries.Kisiler.Queries.GetKisiDetay
{
    public class KisiDetayQuery:IRequest<Response>
    {
        public Guid Id { get; set; }
    }

    public class KisiDetayQueryHandler : IRequestHandler<KisiDetayQuery, Response>
    {
        private readonly IKisiRepository _kisiRepository;
        private readonly IMapper _mapper;

        public KisiDetayQueryHandler(IKisiRepository kisiRepository, IMapper mapper)
        {
            _kisiRepository = kisiRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(KisiDetayQuery request, CancellationToken cancellationToken)
        {
            var kisi = await _kisiRepository.GetKisiDetail(request.Id);
            if (kisi == null)
            {
                var exception = new NotFoundException(nameof(Kisi), request.Id);
                var response = new DataResponse<NotFoundException>(exception,false);
                return response;
            }

            var kisiDto = _mapper.Map<Kisi, KisiVeIletisimDto>(kisi);
            return new DataResponse<KisiVeIletisimDto>(kisiDto,true);
        }
    }
}
