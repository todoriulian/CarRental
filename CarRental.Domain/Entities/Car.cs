using CarRental.Domain.Common;

namespace CarRental.Domain.Entities
{
    public class Car : BaseAuditableEntity
    {
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int ManufactureYear { get; set; }
        public decimal Motor { get; set; }
        public string Fuel { get; set; }
        public int Seats { get; set; }
        public int IdCategory { get; set; }
    }
}
