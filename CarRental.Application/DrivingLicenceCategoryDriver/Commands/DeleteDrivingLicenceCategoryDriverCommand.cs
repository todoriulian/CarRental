using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.DrivingLicenceCategoryDriver.Commands
{
    public record DeleteDrivingLicenceCategoryDriverCommand(Guid Id) : IRequest;

    public class DeleteDrivingLicenceCategoryDriverCommandHandler : IRequest<DeleteDrivingLicenceCategoryDriverCommand>
    {
        private readonly IRepository _repository;

        public DeleteDrivingLicenceCategoryDriverCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteDrivingLicenceCategoryDriverCommand request, CancellationToken cancellationToken)
        {
            _repository.SoftDelete<Domain.Entities.DrivingLicenceCategoryDriver>(request.Id);
            await _repository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}