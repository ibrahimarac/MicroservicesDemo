using AutoMapper;
using ContactReport.Application.Common.Exceptions;
using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Application.CommandQueries.RaporDurumIslemleri.Commands.UpdateRaporDurum
{
    public class UpdateRaporDurumCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
        public string Durum { get; set; }
    }

    public class UpdateRaporDurumCommandHandler : IRequestHandler<UpdateRaporDurumCommand, Response>
    {
        private readonly IRaporDurumRepository _raporDurumRepository;
        private readonly IMapper _mapper;

        public UpdateRaporDurumCommandHandler(IRaporDurumRepository raporDurumRepository,IMapper mapper)
        {
            _raporDurumRepository = raporDurumRepository;
            _mapper = mapper;
        }
        public async Task<Response> Handle(UpdateRaporDurumCommand request, CancellationToken cancellationToken)
        {
            var raporDurumEntity = await _raporDurumRepository.GetById(request.Id);

            if (raporDurumEntity == null)
            {
                var exception = new NotFoundException(nameof(RaporDurum), request.Id);
                var response = new ErrorDataResponse<NotFoundException>(exception);
                return response;
            }
            var kisiUpdatedEntity = _mapper.Map(request, raporDurumEntity);
            await _raporDurumRepository.Update(raporDurumEntity);
            return new SuccessResponse();
        }
    }
}
