
using CarRental.Domain.Common;

namespace CarRental.Domain.Entities
{
    public class CarCategory : BaseAuditableEntity
    {
        public Guid Guid { get; set; }
        public string Description { get; set; } = null!;
    }
}
