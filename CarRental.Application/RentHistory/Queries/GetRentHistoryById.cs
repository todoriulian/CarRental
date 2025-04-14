using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.RentHistory.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.RentHistory.Queries
{
    public class GetRentHistoryByIdQuery : IRequest<RentHistoryDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetRentHistoryByIdQueryHandler : IRequestHandler<GetRentHistoryByIdQuery, RentHistoryDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetRentHistoryByIdQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RentHistoryDTO> Handle(GetRentHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new Common.Exceptions.ApplicationException("Invalid Id");
            }

            var rentHistory = await _repository.GetByIdAsync<Domain.Entities.RentHistory>(request.Id);

            return rentHistory != null ? _mapper.Map<RentHistoryDTO>(rentHistory) : throw new NotFoundException(nameof(RentHistory), request.Id);
        }
    }
}