using AutoMapper;
using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Application.Common.Exceptions;

namespace CarRental.Application.Cars.Commands
{
    public class UpdateCarCommand : IRequest<CarDTO>
    {
        public Guid Guid { get; set; }
        public string LicensePlate { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public int ManufactureYear { get; set; }
        public decimal Motor { get; set; }
        public string Fuel { get; set; } = null!;
        public int Seats { get; set; }
        public int IdCategory { get; set; }
    }

    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, CarDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCarCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CarDTO> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _repository.GetByIdAsync<Car>(request.Guid);
            if (car == null)
            {
                throw new NotFoundException(nameof(Car), request.Guid);
            }

            car.LicensePlate = request.LicensePlate;
            car.Model = request.Model;
            car.Manufacturer = request.Manufacturer;
            car.ManufactureYear = request.ManufactureYear;
            car.Motor = request.Motor;
            car.Fuel = request.Fuel;
            car.Seats = request.Seats;
            car.IdCategory = request.IdCategory;

            _repository.Update(car);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CarDTO>(car);
        }
    }
}