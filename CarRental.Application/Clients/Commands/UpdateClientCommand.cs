using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Clients.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.Clients.Commands
{
    public class UpdateClientCommand : IRequest<ClientDTO>
    {
        public Guid Guid { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Address { get; set; } = null!;
    }

    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, ClientDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateClientCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClientDTO> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _repository.GetByIdAsync<Client>(request.Guid);
            if (client == null)
            {
                throw new NotFoundException(nameof(Client), request.Guid);
            }

            client.Name = request.Name;
            client.BirthDate = request.BirthDate;
            client.Address = request.Address;

            _repository.Update(client);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ClientDTO>(client);
        }
    }
}