using AutoMapper;
using MediatR;
using CarRental.Application.Common.Constants;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Common.Models;
using CarRental.Application.CarDetails.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.CarDetails.Queries
{
    public class GetCarDetailsWithPaginationQuery : IRequest<PaginatedList<CarDetailsDTO>>
    {
        public int PageNumber { get; init; } = PagedConstants.PageNumber;
        public int PageSize { get; init; } = PagedConstants.PageSize;
    }

    public class GetCarDetailsWithPaginationQueryHandler : IRequestHandler<GetCarDetailsWithPaginationQuery, PaginatedList<CarDetailsDTO>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetCarDetailsWithPaginationQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CarDetailsDTO>> Handle(GetCarDetailsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var paginatedCarDetails = await _repository.GetPaginated<CarDetail>(request.PageNumber, request.PageSize);
            return _mapper.Map<PaginatedList<CarDetailsDTO>>(paginatedCarDetails);
        }
    }
}