using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.Cars.Commands;
using CarRental.Application.Cars.Queries;
using CarRental.Application.Common.Models;
using CarRental.Domain.Entities;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CarController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CarDTO>> AddCar(AddCarCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCarById), new { id = result.Guid }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            await _mediator.Send(new DeleteCarCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CarDTO>> UpdateCar(Guid id, UpdateCarCommand command)
        {
            if (id != command.Guid)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetCarById(Guid id)
        {
            var result = await _mediator.Send(new GetCarByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<CarDTO>>> GetCarWithPagination([FromQuery] GetCarWithPaginationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}