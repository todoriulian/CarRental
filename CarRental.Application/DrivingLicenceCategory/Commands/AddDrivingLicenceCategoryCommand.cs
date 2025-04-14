using AutoMapper;
using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Application.DrivingLicenceCategory.Dtos;

namespace CarRental.Application.DrivingLicenceCategory.Commands
{
    public class AddDrivingLicenceCategoryCommand : IRequest<DrivingLicenceCategoryDTO>
    {
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string DrivingLicence { get; set; } = null!;
        public DateTime DrivingLicenceRenew { get; set; }
    }

    public class AddDrivingLicenceCategoryCommandHandler : IRequestHandler<AddDrivingLicenceCategoryCommand, DrivingLicenceCategoryDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddDrivingLicenceCategoryCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DrivingLicenceCategoryDTO> Handle(AddDrivingLicenceCategoryCommand request, CancellationToken cancellationToken)
        {
            var drivingLicenceCategory = new Domain.Entities.DrivingLicenceCategory
            {
                Guid = Guid.NewGuid(),
                Description = request.Description,
                Type = request.Type,
                DrivingLicence = request.DrivingLicence,
                DrivingLicenceRenew = request.DrivingLicenceRenew
            };

            await _repository.InsertAsync(drivingLicenceCategory);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DrivingLicenceCategoryDTO>(drivingLicenceCategory);
        }
    }
}