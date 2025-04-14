using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Rent.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.Rent.Queries
{
    public class GetRentByIdQuery : IRequest<RentDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetRentByIdQueryHandler : IRequestHandler<GetRentByIdQuery, RentDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetRentByIdQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RentDTO> Handle(GetRentByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new Common.Exceptions.ApplicationException("Invalid Id");
            }

            var rent = await _repository.GetByIdAsync<Domain.Entities.Rent>(request.Id);

            return rent != null ? _mapper.Map<RentDTO>(rent) : throw new NotFoundException(nameof(Rent), request.Id);
        }
    }
}