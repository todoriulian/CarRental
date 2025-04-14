using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Payment.Commands
{
    public record DeletePaymentCommand(Guid Id) : IRequest;

    public class DeletePaymentCommandHandler : IRequest<DeletePaymentCommand>
    {
        private readonly IRepository _repository;

        public DeletePaymentCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            _repository.SoftDelete<Domain.Entities.Payment>(request.Id);
            await _repository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}