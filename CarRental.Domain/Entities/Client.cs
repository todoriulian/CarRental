using CarRental.Domain.Common;

namespace CarRental.Domain.Entities
{
    public class Client : BaseAuditableEntity
    {
        public Guid Guid { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Address { get; set; } = null!;
    }
}
