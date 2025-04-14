using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.PriceHistory.Commands;
using CarRental.Application.PriceHistory.Queries;
using CarRental.Application.PriceHistory.Dtos;
using CarRental.Application.Common.Models;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PriceHistoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<PriceHistoryDTO>> AddPriceHistory(AddPriceHistoryCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetPriceHistoryById), new { id = result.Guid }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePriceHistory(Guid id)
        {
            await _mediator.Send(new DeletePriceHistoryCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PriceHistoryDTO>> UpdatePriceHistory(Guid id, UpdatePriceHistoryCommand command)
        {
            if (id != command.Guid)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PriceHistoryDTO>> GetPriceHistoryById(Guid id)
        {
            var result = await _mediator.Send(new GetPriceHistoryByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<PriceHistoryDTO>>> GetPriceHistoryWithPagination([FromQuery] GetPriceHistoryWithPaginationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}