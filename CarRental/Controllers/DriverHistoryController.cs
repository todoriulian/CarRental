using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.DriverHistory.Commands;
using CarRental.Application.DriverHistory.Queries;
using CarRental.Application.DriverHistory.Dtos;
using CarRental.Application.Common.Models;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DriverHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DriverHistoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<DriverHistoryDTO>> AddDriverHistory(AddDriverHistoryCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDriverHistoryById), new { id = result.Guid }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriverHistory(Guid id)
        {
            await _mediator.Send(new DeleteDriverHistoryCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DriverHistoryDTO>> UpdateDriverHistory(Guid id, UpdateDriverHistoryCommand command)
        {
            if (id != command.Guid)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DriverHistoryDTO>> GetDriverHistoryById(Guid id)
        {
            var result = await _mediator.Send(new GetDriverHistoryByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<DriverHistoryDTO>>> GetDriverHistoryWithPagination([FromQuery] GetDriverHistoryWithPaginationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
