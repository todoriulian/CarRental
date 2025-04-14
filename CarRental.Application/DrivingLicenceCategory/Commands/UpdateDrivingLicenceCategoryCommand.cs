using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.DrivingLicenceCategory.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.DrivingLicenceCategory.Commands
{
    public class UpdateDrivingLicenceCategoryCommand : IRequest<DrivingLicenceCategoryDTO>
    {
        public Guid Guid { get; set; }
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string DrivingLicence { get; set; } = null!;
        public DateTime DrivingLicenceRenew { get; set; }
    }

    public class UpdateDrivingLicenceCategoryCommandHandler : IRequestHandler<UpdateDrivingLicenceCategoryCommand, DrivingLicenceCategoryDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDrivingLicenceCategoryCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DrivingLicenceCategoryDTO> Handle(UpdateDrivingLicenceCategoryCommand request, CancellationToken cancellationToken)
        {
            var drivingLicenceCategory = await _repository.GetByIdAsync<Domain.Entities.DrivingLicenceCategory>(request.Guid);
            if (drivingLicenceCategory == null)
            {
                throw new NotFoundException(nameof(DrivingLicenceCategory), request.Guid);
            }

            drivingLicenceCategory.Description = request.Description;
            drivingLicenceCategory.Type = request.Type;
            drivingLicenceCategory.DrivingLicence = request.DrivingLicence;
            drivingLicenceCategory.DrivingLicenceRenew = request.DrivingLicenceRenew;

            _repository.Update(drivingLicenceCategory);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DrivingLicenceCategoryDTO>(drivingLicenceCategory);
        }
    }
}