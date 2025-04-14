using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.DrivingLicenceCategory.Commands;
using CarRental.Application.DrivingLicenceCategory.Queries;
using CarRental.Application.DrivingLicenceCategory.Dtos;
using CarRental.Application.Common.Models;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrivingLicenceCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DrivingLicenceCategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<DrivingLicenceCategoryDTO>> AddDrivingLicenceCategory(AddDrivingLicenceCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDrivingLicenceCategoryById), new { id = result.Guid }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrivingLicenceCategory(Guid id)
        {
            await _mediator.Send(new DeleteDrivingLicenceCategoryCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DrivingLicenceCategoryDTO>> UpdateDrivingLicenceCategory(Guid id, UpdateDrivingLicenceCategoryCommand command)
        {
            if (id != command.Guid)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DrivingLicenceCategoryDTO>> GetDrivingLicenceCategoryById(Guid id)
        {
            var result = await _mediator.Send(new GetDrivingLicenceCategoryByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<DrivingLicenceCategoryDTO>>> GetDrivingLicenceCategoryWithPagination([FromQuery] GetDrivingLicenceCategoryWithPaginationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}