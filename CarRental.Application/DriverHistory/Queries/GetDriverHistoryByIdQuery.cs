using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.DriverHistory.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.DriverHistory.Queries
{
    public class GetDriverHistoryByIdQuery : IRequest<DriverHistoryDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetDriverHistoryByIdQueryHandler : IRequestHandler<GetDriverHistoryByIdQuery, DriverHistoryDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetDriverHistoryByIdQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DriverHistoryDTO> Handle(GetDriverHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new System.ApplicationException("Invalid Id");
            }

            var driverHistory = await _repository.GetByIdAsync<Domain.Entities.DriverHistory>(request.Id);

            return driverHistory != null ? _mapper.Map<DriverHistoryDTO>(driverHistory) : throw new NotFoundException(nameof(DriverHistory), request.Id);
        }
    }
}