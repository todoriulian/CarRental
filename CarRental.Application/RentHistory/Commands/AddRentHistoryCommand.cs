using AutoMapper;
using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Application.RentHistory.Dtos;

namespace CarRental.Application.RentHistory.Commands
{
    public class AddRentHistoryCommand : IRequest<RentHistoryDTO>
    {
        public Guid IdCar { get; set; }
        public Guid IdClient { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool WithDriver { get; set; }
        public Guid? IdEmployees { get; set; }
    }

    public class AddRentHistoryCommandHandler : IRequestHandler<AddRentHistoryCommand, RentHistoryDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddRentHistoryCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RentHistoryDTO> Handle(AddRentHistoryCommand request, CancellationToken cancellationToken)
        {
            var rentHistory = new Domain.Entities.RentHistory
            {
                Guid = Guid.NewGuid(),
                IdCar = request.IdCar,
                IdClient = request.IdClient,
                RentDate = request.RentDate,
                ReturnDate = request.ReturnDate,
                WithDriver = request.WithDriver,
                IdEmployees = request.IdEmployees
            };

            await _repository.InsertAsync(rentHistory);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<RentHistoryDTO>(rentHistory);
        }
    }
}