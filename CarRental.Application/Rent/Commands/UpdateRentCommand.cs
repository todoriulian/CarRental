using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Rent.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.Rent.Commands
{
    public class UpdateRentCommand : IRequest<RentDTO>
    {
        public Guid Guid { get; set; }
        public Guid IdCar { get; set; }
        public bool Available { get; set; }
        public DateTime LastRentDate { get; set; }
    }

    public class UpdateRentCommandHandler : IRequestHandler<UpdateRentCommand, RentDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateRentCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RentDTO> Handle(UpdateRentCommand request, CancellationToken cancellationToken)
        {
            var rent = await _repository.GetByIdAsync<Domain.Entities.Rent>(request.Guid);
            if (rent == null)
            {
                throw new NotFoundException(nameof(Rent), request.Guid);
            }

            rent.IdCar = request.IdCar;
            rent.Available = request.Available;
            rent.LastRentDate = request.LastRentDate;

            _repository.Update(rent);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<RentDTO>(rent);
        }
    }
}