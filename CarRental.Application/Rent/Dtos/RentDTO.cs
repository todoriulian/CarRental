using CarRental.Application.Common.Mapping;
using CarRental.Domain.Entities;

namespace CarRental.Application.Rent.Dtos
{
    public class RentDTO : IMapFrom<Domain.Entities.Rent>
    {
        public Guid Guid { get; set; }
        public Guid IdCar { get; set; }
        public bool Available { get; set; }
        public DateTime LastRentDate { get; set; }
    }
}