using CarRental.Application.Common.Mapping;
using CarRental.Domain.Entities;

namespace CarRental.Application.PriceHistory.Dtos
{
    public class PriceHistoryDTO : IMapFrom<Domain.Entities.PriceHistory>
    {
        public Guid Guid { get; set; }
        public Guid IdCar { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public decimal Price { get; set; }
    }
}