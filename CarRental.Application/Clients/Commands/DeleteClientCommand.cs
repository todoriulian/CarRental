using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Clients.Commands
{
    public record DeleteClientCommand(Guid Id) : IRequest;

    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
    {
        private readonly IRepository _repository;

        public DeleteClientCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            _repository.SoftDelete<Client>(request.Id);
            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}