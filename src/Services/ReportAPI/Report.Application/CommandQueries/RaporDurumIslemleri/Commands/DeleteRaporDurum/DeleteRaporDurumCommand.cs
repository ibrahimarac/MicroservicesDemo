using Assesment.Core.Exceptions;
using Assesment.Core.Results;
using AutoMapper;
using MediatR;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Application.CommandQueries.RaporDurumIslemleri.Commands.DeleteRaporDurum
{
    public class DeleteRaporDurumCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
    }

    public class DeleteRaporDurumCommandHandler : IRequestHandler<DeleteRaporDurumCommand, Response>
    {
        private readonly IRaporDurumRepository _raporDurumRepository;
        private readonly IMapper _mapper;

        public DeleteRaporDurumCommandHandler(IRaporDurumRepository raporDurumRepository,IMapper mapper)
        {
            _raporDurumRepository = raporDurumRepository;
            _mapper = mapper;
        }
        public async Task<Response> Handle(DeleteRaporDurumCommand request, CancellationToken cancellationToken)
        {
            var raporDurumEntity = await _raporDurumRepository.GetById(request.Id);

            if (raporDurumEntity == null)
            {
                var exception = new NotFoundException(nameof(RaporDurum), request.Id);
                var response = new DataResponse<NotFoundException>(exception,false);
                return response;
            }

            await _raporDurumRepository.Delete(request.Id);
            return new SuccessResponse();
        }
    }
}
