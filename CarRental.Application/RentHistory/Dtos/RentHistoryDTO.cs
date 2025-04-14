namespace CarRental.Application.RentHistory.Dtos
{
    public class RentHistoryDTO
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