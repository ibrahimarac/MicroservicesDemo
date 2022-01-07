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
    [Route("api/iletisim")]
    [ApiController]
    public class IletisimController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public IletisimController(IMapper mapper,IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(IletisimDto iletisim)
        {
            var command=_mapper.Map<IletisimDto, CreateIletisimCommand>(iletisim);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteIletisimCommand { Id = id };
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetRaporByIdQuery { Id = id};
            var result = await _mediator.Send(query);
            return result.Success ? Ok(result) : BadRequest(result);
        }

       


    }
}
