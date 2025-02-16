using CarRental.Domain.Common;

namespace CarRental.Domain.Entities
{
    public class CarDetail : BaseAuditableEntity
    {
        public int IdCar { get; set; }
        public DateTime ITP { get; set; }
        public DateTime Assurance { get; set; }
        public DateTime RoadTax { get; set; }
        public string Details { get; set; }
    }
}
