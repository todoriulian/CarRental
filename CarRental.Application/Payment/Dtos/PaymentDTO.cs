namespace CarRental.Application.Payment.Dtos
{
    public class PaymentDTO
    {
        public Guid Guid { get; set; }
        public Guid IdClient { get; set; }
        public Guid IdPriceHistory { get; set; }
        public decimal Total { get; set; }
    }
}