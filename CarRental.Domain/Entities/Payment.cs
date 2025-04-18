using CarRental.Domain.Common;

namespace CarRental.Domain.Entities
{
    public class Payment : BaseAuditableEntity
    {
        public Guid IdClient { get; set; }
        public Guid IdPriceHistory { get; set; }
        public decimal Total { get; set; }

        public Client Client { get; set; } = null!;
        public PriceHistory PriceHistory { get; set; } = null!;
    }
}