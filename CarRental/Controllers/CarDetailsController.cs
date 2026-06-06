using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.CarDetails.Commands;
using CarRental.Application.CarDetails.Queries;
using CarRental.Application.CarDetails.Dtos;
using CarRental.Application.Common.Models;
using CarRental.Domain.Common.Enums;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [Authorize(Roles = $"{UserRole.Admin},{UserRole.Dispatcher}")]
        public async Task<ActionResult<CarDetailsDTO>> AddCarDetails(AddCarDetailCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCarDetailsById), new { id = result.Guid }, result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRole.Admin)]
        public async Task<IActionResult> DeleteCarDetails(Guid id)
        {
            await _mediator.Send(new DeleteCarDetailCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = $"{UserRole.Admin},{UserRole.Dispatcher}")]
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

        [HttpGet("bycar/{carId}")]
        public async Task<ActionResult<List<CarDetailsDTO>>> GetCarDetailsByCarId(Guid carId)
        {
            var result = await _mediator.Send(new GetCarDetailsByCarIdQuery { CarId = carId });
            return Ok(result);
        }
    }
}