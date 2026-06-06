using CarRental.Domain.Common;

namespace CarRental.Domain.Entities
{
    public class ApplicationUser : BaseAuditableEntity
    {
        public string GoogleSubjectId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
