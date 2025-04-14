namespace CarRental.Application.DriverHistory.Dtos
{
    public class DriverHistoryDTO
    {
        public Guid Guid { get; set; }
        public Guid IdCar { get; set; }
        public Guid IdEmployees { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}