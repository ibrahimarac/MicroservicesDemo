using Contact.Application.Interfaces.Repositories;
using Core.Application.Models;
using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.CommandsQueries.RaporRequest.Commands
{
    public class RaporTalepCommand : IRequest<Response>
    {
        public string Konum { get; set; }
    }

    public class GetRaporByKonumQueryHandler : IRequestHandler<RaporTalepCommand, Response>
    {
        private readonly IIletisimRepository _iletisimRepository;

        public GetRaporByKonumQueryHandler(IIletisimRepository iletisimRepository)
        {
            _iletisimRepository = iletisimRepository;
        }

        public async Task<Response> Handle(RaporTalepCommand request, CancellationToken cancellationToken)
        {
            var iletisimEntities = await _iletisimRepository.GetByFilter(i => i.Konum == request.Konum);

            var rapor = new RaporTalep
            {
                TelnoSayisi = iletisimEntities.Count(i => i.Telefon != null),
                Konum = request.Konum,
                KisiSayisi=iletisimEntities.Select(i=>i.KisiId).Distinct().Count()
            };
            return new SuccessDataResponse<RaporTalep>(rapor);
        }
    }

}
