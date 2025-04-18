using CarRental.Domain.Common;

namespace CarRental.Domain.Entities
{
    public class PriceHistory : BaseAuditableEntity
    {
        public Guid IdCar { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public decimal Price { get; set; }

        public Car Car { get; set; } = null!;
    }
}