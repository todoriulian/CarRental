using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.DrivingLicenceCategoryDriver.Commands;
using CarRental.Application.DrivingLicenceCategoryDriver.Queries;
using CarRental.Application.DrivingLicenceCategoryDriver.Dtos;
using CarRental.Application.Common.Models;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrivingLicenceCategoryDriverController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DrivingLicenceCategoryDriverController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<DrivingLicenceCategoryDriverDTO>> AddDrivingLicenceCategoryDriver(AddDrivingLicenceCategoryDriverCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDrivingLicenceCategoryDriverById), new { id = result.Guid }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrivingLicenceCategoryDriver(Guid id)
        {
            await _mediator.Send(new DeleteDrivingLicenceCategoryDriverCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DrivingLicenceCategoryDriverDTO>> UpdateDrivingLicenceCategoryDriver(Guid id, UpdateDrivingLicenceCategoryDriverCommand command)
        {
            if (id != command.Guid)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DrivingLicenceCategoryDriverDTO>> GetDrivingLicenceCategoryDriverById(Guid id)
        {
            var result = await _mediator.Send(new GetDrivingLicenceCategoryDriverByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<DrivingLicenceCategoryDriverDTO>>> GetDrivingLicenceCategoryDriverWithPagination([FromQuery] GetDrivingLicenceCategoryDriverWithPaginationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}