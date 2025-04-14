using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Cars.Queries
{
    public class GetCarByIdQuery : IRequest<CarDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetCarByIdQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CarDTO> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new Common.Exceptions.ApplicationException("Invalid Id");
            }

            var car = await _repository.GetByIdAsync<Car>(request.Id);

            return car != null ? _mapper.Map<CarDTO>(car) : throw new NotFoundException(nameof(Car), request.Id);
        }
    }
}