using CarRental.Application.Common.Mapping;
using CarRental.Domain.Entities;

namespace CarRental.Application.RentHistory.Dtos
{
    public class RentHistoryDTO : IMapFrom<Domain.Entities.RentHistory>
    {
        public Guid Guid { get; set; }
        public Guid IdCar { get; set; }
        public Guid IdClient { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool WithDriver { get; set; }
        public Guid? IdEmployees { get; set; }
    }
}