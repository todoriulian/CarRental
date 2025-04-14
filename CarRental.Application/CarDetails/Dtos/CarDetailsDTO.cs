namespace CarRental.Application.CarDetails.Dtos
{
    public class CarDetailsDTO
    {
        public Guid Guid { get; set; }
        public Guid IdCar { get; set; }
        public DateTime ITP { get; set; }
        public DateTime Assurance { get; set; }
        public DateTime RoadTax { get; set; }
        public string Details { get; set; } = null!;
    }
}