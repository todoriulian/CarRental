using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.CarDetails.Commands;
using CarRental.Application.CarDetails.Queries;
using CarRental.Application.CarDetails.Dtos;
using CarRental.Application.Common.Models;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CarDetailsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CarDetailsDTO>> AddCarDetails(AddCarDetailCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCarDetailsById), new { id = result.Guid }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarDetails(Guid id)
        {
            await _mediator.Send(new DeleteCarDetailCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CarDetailsDTO>> UpdateCarDetails(Guid id, UpdateCarDetailCommand command)
        {
            if (id != command.Guid)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDetailsDTO>> GetCarDetailsById(Guid id)
        {
            var result = await _mediator.Send(new GetCarDetailByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<CarDetailsDTO>>> GetCarDetailsWithPagination([FromQuery] GetCarDetailsWithPaginationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}