using Assesment.Core.Exceptions;
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

        public DeleteIletisimCommandHandler(IIletisimRepository iletisimRepository)
        {
            _iletisimRepository = iletisimRepository;
        }

        public async Task<Response> Handle(DeleteIletisimCommand request, CancellationToken cancellationToken)
        {
            var iletisimEntity = await _iletisimRepository.GetById(request.Id);

            if (iletisimEntity == null)
                return new Response(false, $"{request.Id} anahtarına sahip bir kayıt bulunamadı.");
            
            await _iletisimRepository.Delete(request.Id);

            return new Response(true,"");
        }
    }

}
