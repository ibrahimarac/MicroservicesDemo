using AutoMapper;
using Contact.Application.CommandsQueries.Kisiler.Commands.CreateKisi;
using Contact.Application.CommandsQueries.Kisiler.Commands.DeleteKisi;
using Contact.Application.CommandsQueries.Kisiler.Commands.UpdateKisi;
using Contact.Application.CommandsQueries.Kisiler.Queries.GetKisiDetay;
using Contact.Application.CommandsQueries.Kisiler.Queries.GetKisiler;
using Contact.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [Route("api/kisi")]
    [ApiController]
    public class KisiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public KisiController(IMapper mapper,IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(KisiDto kisi)
        {
            var command=_mapper.Map<KisiDto, CreateKisiCommand>(kisi);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteKisiCommand { Id = id };
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update([FromRoute]Guid id,[FromBody]UpdateKisiDto kisi)
        {
            var command = new UpdateKisiCommand { Id = id,Kisi=kisi };
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = new KisiDetayQuery { Id = id};
            var result = await _mediator.Send(query);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetKisilerQuery();
            var result = await _mediator.Send(query);
            return result.Success ? Ok(result) : BadRequest(result);
        }


    }
}
