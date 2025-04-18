using CarRental.Domain.Common;

namespace CarRental.Domain.Entities
{
    public class Car : BaseAuditableEntity
    {
        public string LicensePlate { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public int ManufactureYear { get; set; }
        public decimal Motor { get; set; }
        public string Fuel { get; set; } = null!;
        public int Seats { get; set; }
        public int IdCategory { get; set; }

        public CarCategory? Category { get; set; }
    }
}
