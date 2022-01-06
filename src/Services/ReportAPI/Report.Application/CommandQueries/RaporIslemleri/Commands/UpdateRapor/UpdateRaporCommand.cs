using AutoMapper;
using ContactReport.Application.Common.Exceptions;
using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
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
        public Guid DurumId { get; set; }
    }

    public class UpdateRaporCommandHandler : IRequestHandler<UpdateRaporCommand, Response>
    {
        private readonly IMapper _mapper;
        private readonly IRaporRepository _raporRepository;

        public UpdateRaporCommandHandler(IMapper mapper,IRaporRepository raporRepository)
        {
            _mapper = mapper;
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
            entity.DurumId = new Guid("2143a48a-7190-4ee0-a894-743733ac09b9");
            await _raporRepository.Update(entity);
            return new SuccessResponse();
        }
    }

}
