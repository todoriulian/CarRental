using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.DriverHistory.Dtos;

namespace CarRental.Application.DriverHistory.Commands
{
    public class UpdateDriverHistoryCommand : IRequest<DriverHistoryDTO>
    {
        public Guid Guid { get; set; }
        public Guid IdCar { get; set; }
        public Guid IdEmployees { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }

    public class UpdateDriverHistoryCommandHandler : IRequestHandler<UpdateDriverHistoryCommand, DriverHistoryDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDriverHistoryCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DriverHistoryDTO> Handle(UpdateDriverHistoryCommand request, CancellationToken cancellationToken)
        {
            var driverHistory = await _repository.GetByIdAsync<Domain.Entities.DriverHistory>(request.Guid);
            if (driverHistory == null)
            {
                throw new NotFoundException(nameof(DriverHistory), request.Guid);
            }

            driverHistory.IdCar = request.IdCar;
            driverHistory.IdEmployees = request.IdEmployees;
            driverHistory.RentDate = request.RentDate;
            driverHistory.ReturnDate = request.ReturnDate;

            _repository.Update(driverHistory);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DriverHistoryDTO>(driverHistory);
        }
    }
}