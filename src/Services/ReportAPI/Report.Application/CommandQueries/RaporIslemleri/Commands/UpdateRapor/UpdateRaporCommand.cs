using Assesment.Core.Exceptions;
using Assesment.Core.Results;
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
                var response = new DataResponse<Rapor>(null,false,$"{entity.Id} anahtar değerine sahip bir rapor bulunamadı.");
                return response;
            }
            //rapor bilgileri güncelleniyor
            entity.DurumId = request.Rapor.DurumId;
            entity.Path = request.Rapor.Path;

            await _raporRepository.Update(entity);
            return new DataResponse<Rapor>(entity,true);
        }
    }

}
