using AutoMapper;
using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Cars.Commands
{
    public class AddCarCommand : IRequest<CarDTO>
    {
        public string LicensePlate { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public int ManufactureYear { get; set; }
        public decimal Motor { get; set; }
        public string Fuel { get; set; } = null!;
        public int Seats { get; set; }
        public Guid IdCategory { get; set; }
    }

    public class AddCarCommandHandler : IRequestHandler<AddCarCommand, CarDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddCarCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CarDTO> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            var car = new Car
            {
                Guid = Guid.NewGuid(),
                LicensePlate = request.LicensePlate,
                Model = request.Model,
                Manufacturer = request.Manufacturer,
                ManufactureYear = request.ManufactureYear,
                Motor = request.Motor,
                Fuel = request.Fuel,
                Seats = request.Seats,
                IdCategory = request.IdCategory
            };

            await _repository.InsertAsync(car);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CarDTO>(car);
        }
    }
}