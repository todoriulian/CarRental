using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.DriverHistory.Commands
{
    public record DeleteDriverHistoryCommand(Guid Id) : IRequest;

    public class DeleteDriverHistoryCommandHandler : IRequestHandler<DeleteDriverHistoryCommand>
    {
        private readonly IRepository _repository;

        public DeleteDriverHistoryCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteDriverHistoryCommand request, CancellationToken cancellationToken)
        {
            _repository.SoftDelete<Domain.Entities.DriverHistory>(request.Id);
            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}