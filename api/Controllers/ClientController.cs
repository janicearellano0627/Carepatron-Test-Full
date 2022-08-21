using Application.Clients.Commands.CreateClientInformation;
using Application.Clients.Commands.UpdateClientInformation;
using Application.Clients.Queries.GetAllClientInformation;
using Application.Services.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ClientLookUpDto>>> GetAll([FromQuery] SearchFilter searchFilter)
        {
            var result = await _mediator.Send(new GetAllClientInformationQuery {  Filter = searchFilter});

            return Ok(result);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateClientInformationCommand command)
         {
             var id = await _mediator.Send(command);

             return Ok(id);
         }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateClientInformationCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }
    }
}
