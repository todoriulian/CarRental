using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Cars.Commands
{
    public record DeleteCarCommand(Guid Id) : IRequest;

    public class DeleteCarCommandHandler : IRequest<DeleteCarCommand>
    {
        private readonly IRepository _repository;

        public DeleteCarCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            _repository.SoftDelete<Car>(request.Id);
            await _repository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}