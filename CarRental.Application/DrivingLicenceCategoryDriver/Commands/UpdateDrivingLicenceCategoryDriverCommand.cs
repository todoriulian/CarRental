using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.DrivingLicenceCategoryDriver.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.DrivingLicenceCategoryDriver.Commands
{
    public class UpdateDrivingLicenceCategoryDriverCommand : IRequest<DrivingLicenceCategoryDriverDTO>
    {
        public Guid Guid { get; set; }
        public Guid IdEmployees { get; set; }
        public Guid IdDrivingLicenceCategory { get; set; }
    }

    public class UpdateDrivingLicenceCategoryDriverCommandHandler : IRequestHandler<UpdateDrivingLicenceCategoryDriverCommand, DrivingLicenceCategoryDriverDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDrivingLicenceCategoryDriverCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DrivingLicenceCategoryDriverDTO> Handle(UpdateDrivingLicenceCategoryDriverCommand request, CancellationToken cancellationToken)
        {
            var drivingLicenceCategoryDriver = await _repository.GetByIdAsync<Domain.Entities.DrivingLicenceCategoryDriver>(request.Guid);
            if (drivingLicenceCategoryDriver == null)
            {
                throw new NotFoundException(nameof(DrivingLicenceCategoryDriver), request.Guid);
            }

            drivingLicenceCategoryDriver.IdEmployees = request.IdEmployees;
            drivingLicenceCategoryDriver.IdDrivingLicenceCategory = request.IdDrivingLicenceCategory;

            _repository.Update(drivingLicenceCategoryDriver);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DrivingLicenceCategoryDriverDTO>(drivingLicenceCategoryDriver);
        }
    }
}