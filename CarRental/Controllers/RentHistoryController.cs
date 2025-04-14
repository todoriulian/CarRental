using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.RentHistory.Commands;
using CarRental.Application.RentHistory.Queries;
using CarRental.Application.RentHistory.Dtos;
using CarRental.Application.Common.Models;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RentHistoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<RentHistoryDTO>> AddRentHistory(AddRentHistoryCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRentHistoryById), new { id = result.Guid }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentHistory(Guid id)
        {
            await _mediator.Send(new DeleteRentHistoryCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RentHistoryDTO>> UpdateRentHistory(Guid id, UpdateRentHistoryCommand command)
        {
            if (id != command.Guid)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentHistoryDTO>> GetRentHistoryById(Guid id)
        {
            var result = await _mediator.Send(new GetRentHistoryByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<RentHistoryDTO>>> GetRentHistoryWithPagination([FromQuery] GetRentHistoryWithPaginationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}