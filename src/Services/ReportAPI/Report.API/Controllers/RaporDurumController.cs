using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Report.Application.CommandQueries.RaporDurumIslemleri.Commands.CreateRaporDurum;
using Report.Application.CommandQueries.RaporDurumIslemleri.Commands.DeleteRaporDurum;
using Report.Application.CommandQueries.RaporDurumIslemleri.Commands.UpdateRaporDurum;
using Report.Application.CommandQueries.RaporDurumIslemleri.Queries.GetRaporDurumlar;
using Report.Application.Dtos;
using System;
using System.Threading.Tasks;

namespace Report.API.Controllers
{
    [Route("api/rapor-durum")]
    [ApiController]
    public class RaporDurumController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RaporDurumController(IMapper mapper,IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(RaporDurumCreateDto raporDurum)
        {
            var result = await _mediator.Send(new CreateRaporDurumCommand { Durum=raporDurum});
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteRaporDurumCommand { Id = id };
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RaporDurumUpdateDto raporDurum)
        {
            var command = new UpdateRaporDurumCommand { Id = id, RaporDurum = raporDurum };
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetRaporDurumlarQuery();
            var result = await _mediator.Send(query);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
