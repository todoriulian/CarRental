using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.RentHistory.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.RentHistory.Commands
{
    public class UpdateRentHistoryCommand : IRequest<RentHistoryDTO>
    {
        public Guid Guid { get; set; }
        public Guid IdCar { get; set; }
        public Guid IdClient { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool WithDriver { get; set; }
        public Guid? IdEmployees { get; set; }
    }

    public class UpdateRentHistoryCommandHandler : IRequestHandler<UpdateRentHistoryCommand, RentHistoryDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateRentHistoryCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RentHistoryDTO> Handle(UpdateRentHistoryCommand request, CancellationToken cancellationToken)
        {
            var rentHistory = await _repository.GetByIdAsync<Domain.Entities.RentHistory>(request.Guid);
            if (rentHistory == null)
            {
                throw new NotFoundException(nameof(RentHistory), request.Guid);
            }

            rentHistory.IdCar = request.IdCar;
            rentHistory.IdClient = request.IdClient;
            rentHistory.RentDate = request.RentDate;
            rentHistory.ReturnDate = request.ReturnDate;
            rentHistory.WithDriver = request.WithDriver;
            rentHistory.IdEmployees = request.IdEmployees;

            _repository.Update(rentHistory);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<RentHistoryDTO>(rentHistory);
        }
    }
}