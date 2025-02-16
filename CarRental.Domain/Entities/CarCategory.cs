
using CarRental.Domain.Common;

namespace CarRental.Domain.Entities
{
    public class CarCategory : BaseAuditableEntity
    {
        public string Description { get; set; }
    }
}
