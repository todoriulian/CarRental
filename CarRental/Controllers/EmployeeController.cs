using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.Employees.Commands;
using CarRental.Application.Employees.Queries;
using CarRental.Application.Employees.Dtos;
using CarRental.Application.Common.Models;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EmployeeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> AddEmployee(AddEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = result.Guid }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            await _mediator.Send(new DeleteEmployeeCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDTO>> UpdateEmployee(Guid id, UpdateEmployeeCommand command)
        {
            if (id != command.Guid)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(Guid id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<EmployeeDTO>>> GetEmployeeWithPagination([FromQuery] GetEmployeeWithPaginationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}