using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.CarDetails.Commands
{
    public record DeleteCarDetailCommand(Guid Id) : IRequest;

    public class DeleteCarDetailCommandHandler : IRequest<DeleteCarDetailCommand>
    {
        private readonly IRepository _repository;

        public DeleteCarDetailCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCarDetailCommand request, CancellationToken cancellationToken)
        {
            _repository.SoftDelete<CarDetail>(request.Id);
            await _repository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}