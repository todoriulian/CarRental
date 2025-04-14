using AutoMapper;
using MediatR;
using CarRental.Application.Common.Constants;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Common.Models;
using CarRental.Application.Clients.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.Clients.Queries
{
    public class GetClientWithPaginationQuery : IRequest<PaginatedList<ClientDTO>>
    {
        public int PageNumber { get; init; } = PagedConstants.PageNumber;
        public int PageSize { get; init; } = PagedConstants.PageSize;
    }

    public class GetClientWithPaginationQueryHandler : IRequestHandler<GetClientWithPaginationQuery, PaginatedList<ClientDTO>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetClientWithPaginationQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ClientDTO>> Handle(GetClientWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var paginatedClients = await _repository.GetPaginated<Client>(request.PageNumber, request.PageSize);
            return _mapper.Map<PaginatedList<ClientDTO>>(paginatedClients);
        }
    }
}