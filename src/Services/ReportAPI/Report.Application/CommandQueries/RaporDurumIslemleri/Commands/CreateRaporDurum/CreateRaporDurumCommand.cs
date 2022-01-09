using Assesment.Core.Results;
using AutoMapper;
using MediatR;
using Report.Application.Dtos;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Application.CommandQueries.RaporDurumIslemleri.Commands.CreateRaporDurum
{
    public class CreateRaporDurumCommand:IRequest<Response>
    {
        public string Durum { get; set; }
    }

    public class CreateRaporDurumCommandHandler : IRequestHandler<CreateRaporDurumCommand, Response>
    {
        private readonly IRaporDurumRepository _raporDurumRepository;
        private readonly IMapper _mapper;

        public CreateRaporDurumCommandHandler(IRaporDurumRepository raporDurumRepository,IMapper mapper)
        {
            _raporDurumRepository = raporDurumRepository;
            _mapper = mapper;
        }
        public async Task<Response> Handle(CreateRaporDurumCommand request, CancellationToken cancellationToken)
        {
            var raporDurumEntity = new RaporDurum { Durum = request.Durum };
            raporDurumEntity.Id = Guid.NewGuid();
            await _raporDurumRepository.Add(raporDurumEntity);
            return new DataResponse<Guid>(raporDurumEntity.Id,true,"");
        }
    }
}
