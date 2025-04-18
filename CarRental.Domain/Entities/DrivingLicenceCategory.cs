using CarRental.Domain.Common;

namespace CarRental.Domain.Entities
{
    public class DrivingLicenceCategory : BaseAuditableEntity
    {
        public Guid Guid { get; set; }
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string DrivingLicence { get; set; } = null!;
        public DateTime DrivingLicenceRenew { get; set; }
    }
}
