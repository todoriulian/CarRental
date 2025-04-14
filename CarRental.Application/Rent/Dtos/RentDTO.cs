namespace CarRental.Application.Rent.Dtos
{
    public class RentDTO
    {
        public Guid Guid { get; set; }
        public Guid IdCar { get; set; }
        public bool Available { get; set; }
        public DateTime LastRentDate { get; set; }
    }
}