using AutoMapper;
using MediatR;
using CarRental.Application.Common.Constants;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Common.Models;
using CarRental.Application.PriceHistory.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.PriceHistory.Queries
{
    public class GetPriceHistoryWithPaginationQuery : IRequest<PaginatedList<PriceHistoryDTO>>
    {
        public int PageNumber { get; init; } = PagedConstants.PageNumber;
        public int PageSize { get; init; } = PagedConstants.PageSize;
    }

    public class GetPriceHistoryWithPaginationQueryHandler : IRequestHandler<GetPriceHistoryWithPaginationQuery, PaginatedList<PriceHistoryDTO>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetPriceHistoryWithPaginationQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<PriceHistoryDTO>> Handle(GetPriceHistoryWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var paginatedPriceHistories = await _repository.GetPaginated<Domain.Entities.PriceHistory>(request.PageNumber, request.PageSize);
            return _mapper.Map<PaginatedList<PriceHistoryDTO>>(paginatedPriceHistories);
        }
    }
}