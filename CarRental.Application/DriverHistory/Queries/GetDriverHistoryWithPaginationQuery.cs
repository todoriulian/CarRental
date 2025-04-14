using AutoMapper;
using MediatR;
using CarRental.Application.Common.Constants;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Common.Models;
using CarRental.Application.DriverHistory.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.DriverHistory.Queries
{
    public class GetDriverHistoryWithPaginationQuery : IRequest<PaginatedList<DriverHistoryDTO>>
    {
        public int PageNumber { get; init; } = PagedConstants.PageNumber;
        public int PageSize { get; init; } = PagedConstants.PageSize;
    }

    public class GetDriverHistoryWithPaginationQueryHandler : IRequestHandler<GetDriverHistoryWithPaginationQuery, PaginatedList<DriverHistoryDTO>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetDriverHistoryWithPaginationQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<DriverHistoryDTO>> Handle(GetDriverHistoryWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var paginatedDriverHistories = await _repository.GetPaginated<Domain.Entities.DriverHistory>(request.PageNumber, request.PageSize);
            return _mapper.Map<PaginatedList<DriverHistoryDTO>>(paginatedDriverHistories);
        }
    }
}