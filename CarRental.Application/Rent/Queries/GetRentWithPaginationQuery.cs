using AutoMapper;
using MediatR;
using CarRental.Application.Common.Constants;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Common.Models;
using CarRental.Application.Rent.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.Rent.Queries
{
    public class GetRentWithPaginationQuery : IRequest<PaginatedList<RentDTO>>
    {
        public int PageNumber { get; init; } = PagedConstants.PageNumber;
        public int PageSize { get; init; } = PagedConstants.PageSize;
    }

    public class GetRentWithPaginationQueryHandler : IRequestHandler<GetRentWithPaginationQuery, PaginatedList<RentDTO>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetRentWithPaginationQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<RentDTO>> Handle(GetRentWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var paginatedRents = await _repository.GetPaginated<Domain.Entities.Rent>(request.PageNumber, request.PageSize);
            return _mapper.Map<PaginatedList<RentDTO>>(paginatedRents);
        }
    }
}