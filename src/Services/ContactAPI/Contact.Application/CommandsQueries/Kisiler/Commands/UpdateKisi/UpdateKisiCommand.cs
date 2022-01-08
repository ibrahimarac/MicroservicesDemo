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

namespace Contact.Application.CommandsQueries.Kisiler.Commands.UpdateKisi
{
    public class UpdateKisiCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
        public KisiUpdateDto Kisi { get; set; }
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
            var kisiEntity = await _kisiRepository.GetById(request.Id);
            if(kisiEntity==null)
            {
                var exception = new NotFoundException(nameof(Kisi), request.Id);
                var response = new DataResponse<NotFoundException>(exception,false);
                return response;
            }
            var kisiUpdatedEntity = _mapper.Map(request.Kisi,kisiEntity);
            await _kisiRepository.Update(kisiEntity);
            return new SuccessResponse();
        }
    }

}
