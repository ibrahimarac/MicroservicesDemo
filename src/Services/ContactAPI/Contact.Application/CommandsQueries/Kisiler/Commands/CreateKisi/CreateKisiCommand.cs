using AutoMapper;
using Contact.Application.Interfaces.Repositories;
using Contact.Domain.Entities;
using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.CommandsQueries.Kisiler.Commands.CreateKisi
{
    public class CreateKisiCommand:IRequest<Response>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
    }

    public class CreateKisiCommandHandler : IRequestHandler<CreateKisiCommand, Response>
    {
        private readonly IKisiRepository _kisiRepository;
        private readonly IMapper _mapper;

        public CreateKisiCommandHandler(IKisiRepository kisiRepository,IMapper mapper)
        {
            _kisiRepository = kisiRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateKisiCommand request, CancellationToken cancellationToken)
        {
            var kisiEntity = _mapper.Map<CreateKisiCommand, Kisi>(request);
            await _kisiRepository.Add(kisiEntity);
            return new SuccessDataResponse<Guid>(kisiEntity.Id);
        }
    }

}
