using CarRental.Domain.Common;

namespace CarRental.Domain.Entities
{
    public class DrivingLicenceCategoryDriver : BaseAuditableEntity
    {
        public Guid Guid { get; set; }
        public Guid IdEmployees { get; set; }
        public Guid IdDrivingLicenceCategory { get; set; }

        public Employee Employee { get; set; } = null!;
        public DrivingLicenceCategory DrivingLicenceCatgory { get; set; } = null!;
    }
}