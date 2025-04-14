using CarRental.Domain.Common;

namespace CarRental.Domain.Entities
{
    public class RentHistory : BaseAuditableEntity
    {
        public Guid Guid { get; set; }
        public Guid IdCar { get; set; }
        public Guid IdClient { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool WithDriver { get; set; }
        public Guid? IdEmployees { get; set; }

        public Car Car { get; set; } = null!;
        public Client Client { get; set; } = null!;
        public Employee? Employee { get; set; }
    }
}