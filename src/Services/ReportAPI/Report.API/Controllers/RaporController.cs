using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Report.Application.CommandQueries.RaporIslemleri.Commands.CreateRapor;
using Report.Application.CommandQueries.RaporIslemleri.Commands.UpdateRapor;
using Report.Application.CommandQueries.RaporIslemleri.Queries.GetRapor;
using Report.Application.CommandQueries.RaporIslemleri.Queries.GetRaporDetay;
using Report.Application.CommandQueries.RaporIslemleri.Queries.GetRaports;
using Report.Application.Dtos;
using System;
using System.Threading.Tasks;

namespace Report.API.Controllers
{
    [Route("api/rapor")]
    [ApiController]
    public class RaporController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RaporController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create()
        {
            var command = new CreateRaporCommand();
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(Guid id, RaporUpdateDto rapor)
        {
            var command = new UpdateRaporCommand { Id = id, Rapor = rapor };
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpGet]
        [Route("detail/get")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetRaportsQuery();
            var result = await _mediator.Send(query);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("detail/get/{id}")]
        public async Task<IActionResult> GetDetailById(Guid id)
        {
            var query = new GetRaporDetayQuery { Id=id};
            var result = await _mediator.Send(query);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetRaporQuery { Id = id };
            var result = await _mediator.Send(query);
            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}
