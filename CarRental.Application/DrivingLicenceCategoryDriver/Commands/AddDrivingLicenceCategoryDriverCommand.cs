using AutoMapper;
using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Application.DrivingLicenceCategoryDriver.Dtos;

namespace CarRental.Application.DrivingLicenceCategoryDriver.Commands
{
    public class AddDrivingLicenceCategoryDriverCommand : IRequest<DrivingLicenceCategoryDriverDTO>
    {
        public Guid IdEmployees { get; set; }
        public Guid IdDrivingLicenceCategory { get; set; }
    }

    public class AddDrivingLicenceCategoryDriverCommandHandler : IRequestHandler<AddDrivingLicenceCategoryDriverCommand, DrivingLicenceCategoryDriverDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddDrivingLicenceCategoryDriverCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DrivingLicenceCategoryDriverDTO> Handle(AddDrivingLicenceCategoryDriverCommand request, CancellationToken cancellationToken)
        {
            var drivingLicenceCategoryDriver = new Domain.Entities.DrivingLicenceCategoryDriver
            {
                Guid = Guid.NewGuid(),
                IdEmployees = request.IdEmployees,
                IdDrivingLicenceCategory = request.IdDrivingLicenceCategory
            };

            await _repository.InsertAsync(drivingLicenceCategoryDriver);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DrivingLicenceCategoryDriverDTO>(drivingLicenceCategoryDriver);
        }
    }
}