using AutoMapper;
using MediatR;
using CarRental.Application.Common.Constants;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Common.Models;
using CarRental.Application.DrivingLicenceCategoryDriver.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.DrivingLicenceCategoryDriver.Queries
{
    public class GetDrivingLicenceCategoryDriverWithPaginationQuery : IRequest<PaginatedList<DrivingLicenceCategoryDriverDTO>>
    {
        public int PageNumber { get; init; } = PagedConstants.PageNumber;
        public int PageSize { get; init; } = PagedConstants.PageSize;
    }

    public class GetDrivingLicenceCategoryDriverWithPaginationQueryHandler : IRequestHandler<GetDrivingLicenceCategoryDriverWithPaginationQuery, PaginatedList<DrivingLicenceCategoryDriverDTO>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetDrivingLicenceCategoryDriverWithPaginationQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<DrivingLicenceCategoryDriverDTO>> Handle(GetDrivingLicenceCategoryDriverWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var paginatedDrivingLicenceCategoryDrivers = await _repository.GetPaginated<Domain.Entities.DrivingLicenceCategoryDriver>(request.PageNumber, request.PageSize);
            return _mapper.Map<PaginatedList<DrivingLicenceCategoryDriverDTO>>(paginatedDrivingLicenceCategoryDrivers);
        }
    }
}