
namespace CarRental.Domain.Common
{
    public abstract class BaseAuditableEntity
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? Deleted { get; set; }

    }
}
