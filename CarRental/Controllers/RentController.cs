using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.Rent.Commands;
using CarRental.Application.Rent.Queries;
using CarRental.Application.Rent.Dtos;
using CarRental.Application.Common.Models;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<RentDTO>> AddRent(AddRentCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRentById), new { id = result.Guid }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent(Guid id)
        {
            await _mediator.Send(new DeleteRentCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RentDTO>> UpdateRent(Guid id, UpdateRentCommand command)
        {
            if (id != command.Guid)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentDTO>> GetRentById(Guid id)
        {
            var result = await _mediator.Send(new GetRentByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<RentDTO>>> GetRentWithPagination([FromQuery] GetRentWithPaginationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}