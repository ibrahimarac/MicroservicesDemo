using AutoMapper;
using Contact.Application.CommandsQueries.IletisimBilgileri.Commands.CreateIletisim;
using Contact.Application.CommandsQueries.IletisimBilgileri.Commands.DeleteIletisim;
using Contact.Application.CommandsQueries.IletisimBilgileri.Queries.GetIletisimById;
using Contact.Application.CommandsQueries.RaporTalep.Queries;
using Contact.Application.Dtos;
using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [Route("api/rapor")]
    [ApiController]
    public class RaporTalepController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RaporTalepController(IMapper mapper,IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("create/{konum}")]
        public async Task<IActionResult> GetByKonum(string konum)
        {
            var query = new RaporTalepQuery();
            var result = await _mediator.Send(query);
            //Eğer rapor bilgileri başarılı bir şekilde elde edilmişse
            return result.Success ? Ok(result) : BadRequest(result);
        }


    }
}
