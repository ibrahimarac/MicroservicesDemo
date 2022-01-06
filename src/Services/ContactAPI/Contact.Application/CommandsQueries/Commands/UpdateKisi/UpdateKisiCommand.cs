using AutoMapper;
using Contact.Application.Interfaces.Repositories;
using Contact.Domain.Entities;
using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.CommandsQueries.Commands.UpdateKisi
{
    public class UpdateKisiCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
    }

    public class UpdateKisiCommandHandler : IRequestHandler<UpdateKisiCommand, Response>
    {
        private readonly IKisiRepository _kisiRepository;
        private readonly IMapper _mapper;

        public UpdateKisiCommandHandler(IKisiRepository kisiRepository,IMapper mapper)
        {
            _kisiRepository = kisiRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateKisiCommand request, CancellationToken cancellationToken)
        {
            var kisiEntity = _mapper.Map<UpdateKisiCommand, Kisi>(request);
            await _kisiRepository.Update(kisiEntity);
            return new SuccessResponse();
        }
    }

}
