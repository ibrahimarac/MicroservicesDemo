using AutoMapper;
using Contact.Application.CommandsQueries.RaporTalep.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [Route("api/rapor")]
    [ApiController]
    public class RaporController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RaporController(IMapper mapper,IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-by-konum/{konum}")]
        public async Task<IActionResult> GetByKonum(string konum)
        {
            var command = new RaporTalepCommand { Konum = konum };
            var result = await _mediator.Send(command);
            //Eğer rapor bilgileri başarılı bir şekilde elde edilmişse
            return result.Success ? Ok(result) : BadRequest(result);
        }


    }
}
