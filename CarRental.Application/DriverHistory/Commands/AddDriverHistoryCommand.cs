using AutoMapper;
using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.DriverHistory.Dtos;

namespace CarRental.Application.DriverHistory.Commands
{
    public class AddDriverHistoryCommand : IRequest<DriverHistoryDTO>
    {
        public Guid IdCar { get; set; }
        public Guid IdEmployees { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }

    public class AddDriverHistoryCommandHandler : IRequestHandler<AddDriverHistoryCommand, DriverHistoryDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddDriverHistoryCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DriverHistoryDTO> Handle(AddDriverHistoryCommand request, CancellationToken cancellationToken)
        {
            var driverHistory = new Domain.Entities.DriverHistory
            {
                Guid = Guid.NewGuid(),
                IdCar = request.IdCar,
                IdEmployees = request.IdEmployees,
                RentDate = request.RentDate,
                ReturnDate = request.ReturnDate
            };

            await _repository.InsertAsync(driverHistory);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DriverHistoryDTO>(driverHistory);
        }
    }
}