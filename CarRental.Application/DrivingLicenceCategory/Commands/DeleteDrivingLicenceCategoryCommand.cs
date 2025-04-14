using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.DrivingLicenceCategory.Commands
{
    public record DeleteDrivingLicenceCategoryCommand(Guid Id) : IRequest;

    public class DeleteDrivingLicenceCategoryCommandHandler : IRequest<DeleteDrivingLicenceCategoryCommand>
    {
        private readonly IRepository _repository;

        public DeleteDrivingLicenceCategoryCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteDrivingLicenceCategoryCommand request, CancellationToken cancellationToken)
        {
            _repository.SoftDelete<Domain.Entities.DrivingLicenceCategory>(request.Id);
            await _repository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}