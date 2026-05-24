using CarRental.Application.Common.Mapping;
using CarRental.Domain.Entities;

namespace CarRental.Application.DriverHistory.Dtos
{
    public class DriverHistoryDTO : IMapFrom<Domain.Entities.DriverHistory>
    {
        public Guid Guid { get; set; }
        public Guid IdCar { get; set; }
        public Guid IdEmployees { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}