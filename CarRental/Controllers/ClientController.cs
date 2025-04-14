using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.Clients.Commands;
using CarRental.Application.Clients.Queries;
using CarRental.Application.Clients.Dtos;
using CarRental.Application.Common.Models;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ClientController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ClientDTO>> AddClient(AddClientCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetClientById), new { id = result.Guid }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            await _mediator.Send(new DeleteClientCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClientDTO>> UpdateClient(Guid id, UpdateClientCommand command)
        {
            if (id != command.Guid)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClientById(Guid id)
        {
            var result = await _mediator.Send(new GetClientByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<ClientDTO>>> GetClientWithPagination([FromQuery] GetClientWithPaginationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}