using AutoMapper;
using ContactReport.Application.Common.Exceptions;
using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
using Report.Application.Dtos;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Application.CommandQueries.RaporIslemleri.Commands.UpdateRapor
{
    public class UpdateRaporCommand : IRequest<Response>
    {
        public Guid Id { get; set; }

        public RaporUpdateDto Rapor { get; set; }
    }

    public class UpdateRaporCommandHandler : IRequestHandler<UpdateRaporCommand, Response>
    {
        private readonly IRaporRepository _raporRepository;

        public UpdateRaporCommandHandler(IRaporRepository raporRepository)
        {
            _raporRepository = raporRepository;
        }

        public async Task<Response> Handle(UpdateRaporCommand request, CancellationToken cancellationToken)
        {
            var entity = await _raporRepository.GetById(request.Id);
            if(entity==null)
            {
                var exception = new NotFoundException(nameof(Rapor), request.Id);
                var response = new ErrorDataResponse<NotFoundException>(exception);
                return response;
            }
            //rapor bilgileri güncelleniyor
            entity.DurumId = request.Rapor.DurumId;
            entity.Path = request.Rapor.Path;

            await _raporRepository.Update(entity);
            return new SuccessResponse();
        }
    }

}
