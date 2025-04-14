using AutoMapper;
using MediatR;
using CarRental.Application.Common.Constants;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Common.Models;
using CarRental.Application.Employees.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.Employees.Queries
{
    public class GetEmployeeWithPaginationQuery : IRequest<PaginatedList<EmployeeDTO>>
    {
        public int PageNumber { get; init; } = PagedConstants.PageNumber;
        public int PageSize { get; init; } = PagedConstants.PageSize;
    }

    public class GetEmployeeWithPaginationQueryHandler : IRequestHandler<GetEmployeeWithPaginationQuery, PaginatedList<EmployeeDTO>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetEmployeeWithPaginationQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<EmployeeDTO>> Handle(GetEmployeeWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var paginatedEmployees = await _repository.GetPaginated<Employee>(request.PageNumber, request.PageSize);
            return _mapper.Map<PaginatedList<EmployeeDTO>>(paginatedEmployees);
        }
    }
}