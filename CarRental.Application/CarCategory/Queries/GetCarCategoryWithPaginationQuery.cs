using AutoMapper;
using MediatR;
using CarRental.Application.Common.Constants;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Common.Models;
using CarRental.Domain.Entities;
using CarRental.Application.CarCategories.Dtos;

namespace CarRental.Application.CarCategories.Queries
{
    public class GetCarCategoryWithPaginationQuery : IRequest<PaginatedList<CarCategoryDTO>>
    {
        public int PageNumber { get; init; } = PagedConstants.PageNumber;
        public int PageSize { get; init; } = PagedConstants.PageSize;
    }

    public class GetCarCategoryWithPaginationQueryHandler : IRequestHandler<GetCarCategoryWithPaginationQuery, PaginatedList<CarCategoryDTO>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetCarCategoryWithPaginationQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CarCategoryDTO>> Handle(GetCarCategoryWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var paginatedCarCategories = await _repository.GetPaginated<CarCategory>(request.PageNumber, request.PageSize);
            return _mapper.Map<PaginatedList<CarCategoryDTO>>(paginatedCarCategories);
        }
    }
}