using AutoMapper;
using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Application.CommandQueries.RaporIslemleri.Commands.CreateRapor
{
    public class CreateRaporCommand:IRequest<Response>
    {

    }

    public class CreateRaporCommandHandler : IRequestHandler<CreateRaporCommand, Response>
    {
        private readonly IMapper _mapper;
        private readonly IRaporRepository _raporRepository;

        public CreateRaporCommandHandler(IMapper mapper,IRaporRepository raporRepository)
        {
            _mapper = mapper;
            _raporRepository = raporRepository;
        }

        public async Task<Response> Handle(CreateRaporCommand request, CancellationToken cancellationToken)
        {
            var entity = new Rapor
            {
                Id = Guid.NewGuid(),
                DurumId = new Guid("54a0bfc0-d88d-4e75-a067-9547e977c926")
            };
            await _raporRepository.Add(entity);
            return new SuccessDataResponse<Guid>(entity.Id);
        }
    }

}
