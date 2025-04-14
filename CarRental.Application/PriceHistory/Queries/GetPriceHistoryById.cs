using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.PriceHistory.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.PriceHistory.Queries
{
    public class GetPriceHistoryByIdQuery : IRequest<PriceHistoryDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetPriceHistoryByIdQueryHandler : IRequestHandler<GetPriceHistoryByIdQuery, PriceHistoryDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetPriceHistoryByIdQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PriceHistoryDTO> Handle(GetPriceHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new Common.Exceptions.ApplicationException("Invalid Id");
            }

            var priceHistory = await _repository.GetByIdAsync<Domain.Entities.PriceHistory>(request.Id);

            return priceHistory != null ? _mapper.Map<PriceHistoryDTO>(priceHistory) : throw new NotFoundException(nameof(PriceHistory), request.Id);
        }
    }
}