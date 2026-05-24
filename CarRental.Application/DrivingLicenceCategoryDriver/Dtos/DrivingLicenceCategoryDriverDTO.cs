using CarRental.Application.Common.Mapping;
using CarRental.Domain.Entities;

namespace CarRental.Application.DrivingLicenceCategoryDriver.Dtos
{
    public class DrivingLicenceCategoryDriverDTO : IMapFrom<Domain.Entities.DrivingLicenceCategoryDriver>
    {
        public Guid Guid { get; set; }
        public Guid IdEmployees { get; set; }
        public Guid IdDrivingLicenceCategory { get; set; }
    }
}