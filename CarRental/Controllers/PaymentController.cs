using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.Payment.Commands;
using CarRental.Application.Payment.Queries;
using CarRental.Application.Payment.Dtos;
using CarRental.Application.Common.Models;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PaymentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<PaymentDTO>> AddPayment(AddPaymentCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetPaymentById), new { id = result.Guid }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(Guid id)
        {
            await _mediator.Send(new DeletePaymentCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PaymentDTO>> UpdatePayment(Guid id, UpdatePaymentCommand command)
        {
            if (id != command.Guid)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDTO>> GetPaymentById(Guid id)
        {
            var result = await _mediator.Send(new GetPaymentByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<PaymentDTO>>> GetPaymentWithPagination([FromQuery] GetPaymentWithPaginationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}