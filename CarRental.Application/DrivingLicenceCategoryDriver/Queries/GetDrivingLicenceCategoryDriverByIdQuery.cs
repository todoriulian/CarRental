using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.DrivingLicenceCategoryDriver.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.DrivingLicenceCategoryDriver.Queries
{
    public class GetDrivingLicenceCategoryDriverByIdQuery : IRequest<DrivingLicenceCategoryDriverDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetDrivingLicenceCategoryDriverByIdQueryHandler : IRequestHandler<GetDrivingLicenceCategoryDriverByIdQuery, DrivingLicenceCategoryDriverDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetDrivingLicenceCategoryDriverByIdQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DrivingLicenceCategoryDriverDTO> Handle(GetDrivingLicenceCategoryDriverByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new Common.Exceptions.ApplicationException("Invalid Id");
            }

            var drivingLicenceCategoryDriver = await _repository.GetByIdAsync<Domain.Entities.DrivingLicenceCategoryDriver>(request.Id);

            return drivingLicenceCategoryDriver != null ? _mapper.Map<DrivingLicenceCategoryDriverDTO>(drivingLicenceCategoryDriver) : throw new NotFoundException(nameof(DrivingLicenceCategoryDriver), request.Id);
        }
    }
}