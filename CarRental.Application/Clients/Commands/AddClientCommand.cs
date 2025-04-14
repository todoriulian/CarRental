using AutoMapper;
using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Application.Clients.Dtos;

namespace CarRental.Application.Clients.Commands
{
    public class AddClientCommand : IRequest<ClientDTO>
    {
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Address { get; set; } = null!;
    }

    public class AddClientCommandHandler : IRequestHandler<AddClientCommand, ClientDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddClientCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClientDTO> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client
            {
                Guid = Guid.NewGuid(),
                Name = request.Name,
                BirthDate = request.BirthDate,
                Address = request.Address
            };

            await _repository.InsertAsync(client);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ClientDTO>(client);
        }
    }
}