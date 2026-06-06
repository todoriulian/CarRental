using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.RentHistory.Commands;
using CarRental.Application.RentHistory.Queries;
using CarRental.Application.RentHistory.Dtos;
using CarRental.Application.Common.Models;
using CarRental.Domain.Common.Enums;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [Authorize(Roles = $"{UserRole.Admin},{UserRole.Dispatcher}")]
        public async Task<ActionResult<RentHistoryDTO>> AddRentHistory(AddRentHistoryCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRentHistoryById), new { id = result.Guid }, result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRole.Admin)]
        public async Task<IActionResult> DeleteRentHistory(Guid id)
        {
            await _mediator.Send(new DeleteRentHistoryCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = $"{UserRole.Admin},{UserRole.Dispatcher}")]
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