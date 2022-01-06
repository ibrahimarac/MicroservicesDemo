using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Application.CommandQueries.RaporIslemleri.Queries.RaporTalep
{
    public class RaporTalepQuery:IRequest<Response>
    {
        public string Konum { get; set; }
    }

    public class RaporTalepQueryHandler : IRequestHandler<RaporTalepQuery, Response>
    {
        private readonly IRaporRepository _raporRepository;

        public RaporTalepQueryHandler(IRaporRepository raporRepository)
        {
            _raporRepository = raporRepository;
        }

        public async Task<Response> Handle(RaporTalepQuery request, CancellationToken cancellationToken)
        {
            //rapor talebi geldiğinden hemen yeni bir kayıt açarak durumunu hazırlanıyor olarak ayarlayalım.
            var rapor = new Rapor
            {
                Id=Guid.NewGuid(),
                DurumId= new Guid("54a0bfc0-d88d-4e75-a067-9547e977c926")
            };
            await _raporRepository.Add(rapor);
            return new SuccessDataResponse<Guid>(rapor.Id);
        }

    }
}
