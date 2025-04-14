using AutoMapper;
using MediatR;
using CarRental.Application.Common.Constants;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Common.Models;
using CarRental.Application.RentHistory.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.RentHistory.Queries
{
    public class GetRentHistoryWithPaginationQuery : IRequest<PaginatedList<RentHistoryDTO>>
    {
        public int PageNumber { get; init; } = PagedConstants.PageNumber;
        public int PageSize { get; init; } = PagedConstants.PageSize;
    }

    public class GetRentHistoryWithPaginationQueryHandler : IRequestHandler<GetRentHistoryWithPaginationQuery, PaginatedList<RentHistoryDTO>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetRentHistoryWithPaginationQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<RentHistoryDTO>> Handle(GetRentHistoryWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var paginatedRentHistories = await _repository.GetPaginated<Domain.Entities.RentHistory>(request.PageNumber, request.PageSize);
            return _mapper.Map<PaginatedList<RentHistoryDTO>>(paginatedRentHistories);
        }
    }
}