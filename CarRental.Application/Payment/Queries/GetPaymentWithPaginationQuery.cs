using AutoMapper;
using MediatR;
using CarRental.Application.Common.Constants;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Common.Models;
using CarRental.Application.Payment.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.Payment.Queries
{
    public class GetPaymentWithPaginationQuery : IRequest<PaginatedList<PaymentDTO>>
    {
        public int PageNumber { get; init; } = PagedConstants.PageNumber;
        public int PageSize { get; init; } = PagedConstants.PageSize;
    }

    public class GetPaymentWithPaginationQueryHandler : IRequestHandler<GetPaymentWithPaginationQuery, PaginatedList<PaymentDTO>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetPaymentWithPaginationQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<PaymentDTO>> Handle(GetPaymentWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var paginatedPayments = await _repository.GetPaginated<Domain.Entities.Payment>(request.PageNumber, request.PageSize);
            return _mapper.Map<PaginatedList<PaymentDTO>>(paginatedPayments);
        }
    }
}