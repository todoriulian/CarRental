using AutoMapper;
using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Application.Payment.Dtos;

namespace CarRental.Application.Payment.Commands
{
    public class AddPaymentCommand : IRequest<PaymentDTO>
    {
        public Guid IdClient { get; set; }
        public Guid IdPriceHistory { get; set; }
        public decimal Total { get; set; }
    }

    public class AddPaymentCommandHandler : IRequestHandler<AddPaymentCommand, PaymentDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddPaymentCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaymentDTO> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = new Domain.Entities.Payment
            {
                Guid = Guid.NewGuid(),
                IdClient = request.IdClient,
                IdPriceHistory = request.IdPriceHistory,
                Total = request.Total
            };

            await _repository.InsertAsync(payment);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<PaymentDTO>(payment);
        }
    }
}