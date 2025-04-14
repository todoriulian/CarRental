using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Payment.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.Payment.Commands
{
    public class UpdatePaymentCommand : IRequest<PaymentDTO>
    {
        public Guid Guid { get; set; }
        public Guid IdClient { get; set; }
        public Guid IdPriceHistory { get; set; }
        public decimal Total { get; set; }
    }

    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, PaymentDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePaymentCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaymentDTO> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _repository.GetByIdAsync<Domain.Entities.Payment>(request.Guid);
            if (payment == null)
            {
                throw new NotFoundException(nameof(Payment), request.Guid);
            }

            payment.IdClient = request.IdClient;
            payment.IdPriceHistory = request.IdPriceHistory;
            payment.Total = request.Total;

            _repository.Update(payment);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<PaymentDTO>(payment);
        }
    }
}