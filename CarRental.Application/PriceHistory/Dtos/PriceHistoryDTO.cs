namespace CarRental.Application.PriceHistory.Dtos
{
    public class PriceHistoryDTO
    {
        public Guid Guid { get; set; }
        public Guid IdCar { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public decimal Price { get; set; }
    }
}