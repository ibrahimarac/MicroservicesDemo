using Assesment.Core.Results;
using AutoMapper;
using Contact.Application.Dtos;
using Contact.Application.Interfaces.Repositories;
using Contact.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.CommandsQueries.IletisimBilgileri.Queries.GetIletisimById
{
    public class GetRaporByIdQuery : IRequest<Response>
    {
        public Guid Id { get; set; }
    }

    public class GetRaporByIdQueryHandler : IRequestHandler<GetRaporByIdQuery, Response>
    {
        private readonly IIletisimRepository _iletisimRepository;
        private readonly IMapper _mapper;

        public GetRaporByIdQueryHandler(IIletisimRepository iletisimRepository, IMapper mapper)
        {
            _iletisimRepository = iletisimRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetRaporByIdQuery request, CancellationToken cancellationToken)
        {
            var iletisimEntity = await _iletisimRepository.GetById(request.Id);
            var iletisimDto=_mapper.Map<Iletisim, IletisimDto>(iletisimEntity);
            return new DataResponse<IletisimDto>(iletisimDto,true);
        }
    }

}
