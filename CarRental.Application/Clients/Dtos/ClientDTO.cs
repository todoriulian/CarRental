namespace CarRental.Application.Clients.Dtos
{
    public class ClientDTO
    {
        public Guid Guid { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Address { get; set; } = null!;
    }
}