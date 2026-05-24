using CarRental.Application.Common.Mapping;
using CarRental.Domain.Entities;

namespace CarRental.Application.Cars.Dtos
{
    public class CarDTO : IMapFrom<Car>
    {
        public Guid Guid { get; set; }
        public string LicensePlate { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public int ManufactureYear { get; set; }
        public decimal Motor { get; set; }
        public string Fuel { get; set; } = null!;
        public int Seats { get; set; }
        public Guid IdCategory { get; set; }
        public string? CategoryDescription { get; set; }
    }
}