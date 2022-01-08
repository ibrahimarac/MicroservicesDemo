using Assesment.Core.Exceptions;
using Assesment.Core.Results;
using AutoMapper;
using Contact.Application.Interfaces.Repositories;
using Contact.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.CommandsQueries.Kisiler.Commands.DeleteKisi
{
    public class DeleteKisiCommand:IRequest<Response>
    {
        public Guid Id { get; set; }
    }

    public class DeleteKisiCommandHandler : IRequestHandler<DeleteKisiCommand, Response>
    {
        private readonly IKisiRepository _kisiRepository;
        private readonly IMapper _mapper;

        public DeleteKisiCommandHandler(IKisiRepository kisiRepository,IMapper mapper)
        {
            _kisiRepository = kisiRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(DeleteKisiCommand request, CancellationToken cancellationToken)
        {
            var kisi = await _kisiRepository.GetById(request.Id);
            if(kisi==null)
            {
                var exception = new NotFoundException(nameof(Kisi), request.Id);
                var response = new DataResponse<NotFoundException>(exception,false);
                return response;
            }

            var kisiEntity = _mapper.Map<DeleteKisiCommand, Kisi>(request);
            await _kisiRepository.Delete(request.Id);
            return new SuccessResponse();
        }
    }

}
