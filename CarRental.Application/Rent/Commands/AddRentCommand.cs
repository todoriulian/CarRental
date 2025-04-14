using AutoMapper;
using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Application.Rent.Dtos;

namespace CarRental.Application.Rent.Commands
{
    public class AddRentCommand : IRequest<RentDTO>
    {
        public Guid IdCar { get; set; }
        public bool Available { get; set; }
        public DateTime LastRentDate { get; set; }
    }

    public class AddRentCommandHandler : IRequestHandler<AddRentCommand, RentDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddRentCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RentDTO> Handle(AddRentCommand request, CancellationToken cancellationToken)
        {
            var rent = new Domain.Entities.Rent
            {
                Guid = Guid.NewGuid(),
                IdCar = request.IdCar,
                Available = request.Available,
                LastRentDate = request.LastRentDate
            };

            await _repository.InsertAsync(rent);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<RentDTO>(rent);
        }
    }
}