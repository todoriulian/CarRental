using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.PriceHistory.Commands
{
    public record DeletePriceHistoryCommand(Guid Id) : IRequest;

    public class DeletePriceHistoryCommandHandler : IRequestHandler<DeletePriceHistoryCommand>
    {
        private readonly IRepository _repository;

        public DeletePriceHistoryCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeletePriceHistoryCommand request, CancellationToken cancellationToken)
        {
            _repository.SoftDelete<Domain.Entities.PriceHistory>(request.Id);
            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}