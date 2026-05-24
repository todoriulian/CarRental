using CarRental.Application.Common.Mapping;
using CarRental.Domain.Entities;

namespace CarRental.Application.Clients.Dtos
{
    public class ClientDTO : IMapFrom<Client>
    {
        public Guid Guid { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Address { get; set; } = null!;
    }
}