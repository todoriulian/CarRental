namespace CarRental.Application.DrivingLicenceCategory.Dtos
{
    public class DrivingLicenceCategoryDTO
    {
        public Guid Guid { get; set; }
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string DrivingLicence { get; set; } = null!;
        public DateTime DrivingLicenceRenew { get; set; }
    }
}