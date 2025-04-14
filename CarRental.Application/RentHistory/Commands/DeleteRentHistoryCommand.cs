using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.RentHistory.Commands
{
    public record DeleteRentHistoryCommand(Guid Id) : IRequest;

    public class DeleteRentHistoryCommandHandler : IRequest<DeleteRentHistoryCommand>
    {
        private readonly IRepository _repository;

        public DeleteRentHistoryCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteRentHistoryCommand request, CancellationToken cancellationToken)
        {
            _repository.SoftDelete<Domain.Entities.RentHistory>(request.Id);
            await _repository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}