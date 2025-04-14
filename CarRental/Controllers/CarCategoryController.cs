using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.CarCategories.Commands;
using CarRental.Application.CarCategories.Queries;
using CarRental.Application.CarCategories.Dtos;
using CarRental.Application.Common.Models;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CarCategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CarCategoryDTO>> AddCarCategory(AddCarCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCarCategoryById), new { id = result.Guid }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarCategory(Guid id)
        {
            await _mediator.Send(new DeleteCarCategoryCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CarCategoryDTO>> UpdateCarCategory(Guid id, UpdateCarCategoryCommand command)
        {
            if (id != command.Guid)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarCategoryDTO>> GetCarCategoryById(Guid id)
        {
            var result = await _mediator.Send(new GetCarCategoryByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<CarCategoryDTO>>> GetCarCategoryWithPagination([FromQuery] GetCarCategoryWithPaginationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}