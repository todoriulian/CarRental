using CarRental.Domain.Common;

namespace CarRental.Domain.Entities
{
    public class DrivingLicenceCatgory : BaseAuditableEntity
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public string DrivingLicence { get; set; }
        public DateTime DrivingLicenceRenew { get; set; }
    }
}
