﻿using AutoMapper;
using Contact.Application.Dtos;
using Contact.Application.Interfaces.Repositories;
using Contact.Domain.Entities;
using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.CommandsQueries.IletisimBilgileri.Queries.GetIletisimByKonum
{
    public class GetRaporByKonumQuery : IRequest<Response>
    {
        public string Konum { get; set; }
    }

    public class GetRaporByKonumQueryHandler : IRequestHandler<GetRaporByKonumQuery, Response>
    {
        private readonly IIletisimRepository _iletisimRepository;

        public GetRaporByKonumQueryHandler(IIletisimRepository iletisimRepository)
        {
            _iletisimRepository = iletisimRepository;
        }

        public async Task<Response> Handle(GetRaporByKonumQuery request, CancellationToken cancellationToken)
        {
            var iletisimEntities = await _iletisimRepository.GetByFilter(i => i.Konum == request.Konum);

            var raporDto = new RaporDto
            {
                TelnoSayisi = iletisimEntities.Count(i => i.Telefon != null),
                Konum = request.Konum,
                KisiSayisi=iletisimEntities.Select(i=>i.KisiId).Distinct().Count()
            };
            return new SuccessDataResponse<RaporDto>(raporDto);
        }
    }

}
