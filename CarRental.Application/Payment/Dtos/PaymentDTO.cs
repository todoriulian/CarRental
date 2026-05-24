using CarRental.Application.Common.Mapping;
using CarRental.Domain.Entities;

namespace CarRental.Application.Payment.Dtos
{
    public class PaymentDTO : IMapFrom<Domain.Entities.Payment>
    {
        public Guid Guid { get; set; }
        public Guid IdClient { get; set; }
        public Guid IdPriceHistory { get; set; }
        public decimal Total { get; set; }
    }
}