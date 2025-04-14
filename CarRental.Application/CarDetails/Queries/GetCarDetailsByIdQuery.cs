using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.CarDetails.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.CarDetails.Queries
{
    public class GetCarDetailByIdQuery : IRequest<CarDetailsDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetCarDetailByIdQueryHandler : IRequestHandler<GetCarDetailByIdQuery, CarDetailsDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetCarDetailByIdQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CarDetailsDTO> Handle(GetCarDetailByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new System.ApplicationException("Invalid Id");
            }

            var carDetail = await _repository.GetByIdAsync<CarDetail>(request.Id);

            return carDetail != null ? _mapper.Map<CarDetailsDTO>(carDetail) : throw new NotFoundException(nameof(CarDetail), request.Id);
        }
    }
}