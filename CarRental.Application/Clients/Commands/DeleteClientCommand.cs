using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Clients.Commands
{
    public record DeleteClientCommand(Guid Id) : IRequest;

    public class DeleteClientCommandHandler : IRequest<DeleteClientCommand>
    {
        private readonly IRepository _repository;

        public DeleteClientCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            _repository.SoftDelete<Client>(request.Id);
            await _repository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}