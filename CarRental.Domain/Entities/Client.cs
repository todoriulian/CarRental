using CarRental.Domain.Common;

namespace CarRental.Domain.Entities
{
    public class Client : BaseAuditableEntity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
    }
}
