using CarRental.Domain.Common;

namespace CarRental.Domain.Entities
{
    public class DriverHistory : BaseAuditableEntity
    {
        public Guid IdCar { get; set; }
        public Guid IdEmployees { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public Car Car { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
    }
}