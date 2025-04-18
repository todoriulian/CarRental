using CarRental.Domain.Common;

namespace CarRental.Domain.Entities
{
    public class Rent : BaseAuditableEntity
    {
        public Guid IdCar { get; set; }
        public bool Available { get; set; }
        public DateTime LastRentDate { get; set; }

        public Car Car { get; set; } = null!;
    }
}