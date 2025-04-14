using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Payment.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.Payment.Queries
{
    public class GetPaymentByIdQuery : IRequest<PaymentDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, PaymentDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetPaymentByIdQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaymentDTO> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new Common.Exceptions.ApplicationException("Invalid Id");
            }

            var payment = await _repository.GetByIdAsync<Domain.Entities.Payment>(request.Id);

            return payment != null ? _mapper.Map<PaymentDTO>(payment) : throw new NotFoundException(nameof(Payment), request.Id);
        }
    }
}