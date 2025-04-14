using AutoMapper;
using MediatR;
using CarRental.Application.Common.Constants;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Common.Models;
using CarRental.Domain.Entities;

namespace CarRental.Application.Cars.Queries
{
    public class GetCarWithPaginationQuery : IRequest<PaginatedList<CarDTO>>
    {
        public int PageNumber { get; init; } = PagedConstants.PageNumber;
        public int PageSize { get; init; } = PagedConstants.PageSize;
    }

    public class GetCarWithPaginationQueryHandler : IRequestHandler<GetCarWithPaginationQuery, PaginatedList<CarDTO>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetCarWithPaginationQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CarDTO>> Handle(GetCarWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var paginatedCars = await _repository.GetPaginated<Car>(request.PageNumber, request.PageSize);
            return _mapper.Map<PaginatedList<CarDTO>>(paginatedCars);
        }
    }
}