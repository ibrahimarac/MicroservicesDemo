using AutoMapper;
using Contact.Application.Interfaces.Repositories;
using Contact.Domain.Entities;
using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.CommandsQueries.IletisimBilgileri.Commands.CreateIletisim
{
    public class CreateIletisimCommand:IRequest<Response>
    {
        public Guid KisiId { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Konum { get; set; }
    }

    public class CreateIletisimCommandHandler : IRequestHandler<CreateIletisimCommand, Response>
    {
        private readonly IIletisimRepository _iletisimRepository;
        private readonly IMapper _mapper;

        public CreateIletisimCommandHandler(IIletisimRepository iletisimRepository,IMapper mapper)
        {
            _iletisimRepository = iletisimRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateIletisimCommand request, CancellationToken cancellationToken)
        {
            var entity=_mapper.Map<CreateIletisimCommand, Iletisim>(request);
            await _iletisimRepository.Add(entity);
            return new SuccessDataResponse<Guid>(entity.Id);
        }
    }

}
