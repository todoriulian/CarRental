using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Clients.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.Clients.Queries
{
    public class GetClientByIdQuery : IRequest<ClientDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetClientByIdQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClientDTO> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new System.ApplicationException("Invalid Id");
            }

            var client = await _repository.GetByIdAsync<Client>(request.Id);

            return client != null ? _mapper.Map<ClientDTO>(client) : throw new NotFoundException(nameof(Client), request.Id);
        }
    }
}