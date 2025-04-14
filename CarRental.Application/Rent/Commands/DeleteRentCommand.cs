using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Rent.Commands
{
    public record DeleteRentCommand(Guid Id) : IRequest;

    public class DeleteRentCommandHandler : IRequest<DeleteRentCommand>
    {
        private readonly IRepository _repository;

        public DeleteRentCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteRentCommand request, CancellationToken cancellationToken)
        {
            _repository.SoftDelete<Domain.Entities.Rent>(request.Id);
            await _repository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}