using Assesment.Core.Results;
using AutoMapper;
using Contact.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.CommandsQueries.IletisimBilgileri.Commands.DeleteIletisim
{
    public class DeleteIletisimCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
    }

    public class DeleteIletisimCommandHandler : IRequestHandler<DeleteIletisimCommand, Response>
    {
        private readonly IIletisimRepository _iletisimRepository;
        private readonly IMapper _mapper;

        public DeleteIletisimCommandHandler(IIletisimRepository iletisimRepository,IMapper mapper)
        {
            _iletisimRepository = iletisimRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(DeleteIletisimCommand request, CancellationToken cancellationToken)
        {
            await _iletisimRepository.Delete(request.Id);
            return new SuccessResponse();
        }
    }

}
