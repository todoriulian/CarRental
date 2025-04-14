using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.CarCategories.Commands
{
    public record DeleteCarCategoryCommand(Guid Id) : IRequest;

    public class DeleteCarCategoryCommandHandler : IRequest<DeleteCarCategoryCommand>
    {
        private readonly IRepository _repository;

        public DeleteCarCategoryCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCarCategoryCommand request, CancellationToken cancellationToken)
        {
            _repository.SoftDelete<CarCategory>(request.Id);
            await _repository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}