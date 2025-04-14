using AutoMapper;
using MediatR;
using CarRental.Application.Common.Constants;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Common.Models;
using CarRental.Application.DrivingLicenceCategory.Dtos;

namespace CarRental.Application.DrivingLicenceCategory.Queries
{
    public class GetDrivingLicenceCategoryWithPaginationQuery : IRequest<PaginatedList<DrivingLicenceCategoryDTO>>
    {
        public int PageNumber { get; init; } = PagedConstants.PageNumber;
        public int PageSize { get; init; } = PagedConstants.PageSize;
    }

    public class GetDrivingLicenceCategoryWithPaginationQueryHandler : IRequestHandler<GetDrivingLicenceCategoryWithPaginationQuery, PaginatedList<DrivingLicenceCategoryDTO>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetDrivingLicenceCategoryWithPaginationQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<DrivingLicenceCategoryDTO>> Handle(GetDrivingLicenceCategoryWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var paginatedDrivingLicenceCategories = await _repository.GetPaginated<Domain.Entities.DrivingLicenceCategory>(request.PageNumber, request.PageSize);
            return _mapper.Map<PaginatedList<DrivingLicenceCategoryDTO>>(paginatedDrivingLicenceCategories);
        }
    }
}