using AutoMapper;
using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Application.CarDetails.Dtos;

namespace CarRental.Application.CarDetails.Commands
{
    public class AddCarDetailCommand : IRequest<CarDetailsDTO>
    {
        public Guid IdCar { get; set; }
        public DateTime ITP { get; set; }
        public DateTime Assurance { get; set; }
        public DateTime RoadTax { get; set; }
        public string Details { get; set; } = null!;
    }

    public class AddCarDetailCommandHandler : IRequestHandler<AddCarDetailCommand, CarDetailsDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddCarDetailCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CarDetailsDTO> Handle(AddCarDetailCommand request, CancellationToken cancellationToken)
        {
            var carDetail = new CarDetail
            {
                Guid = Guid.NewGuid(),
                IdCar = request.IdCar,
                ITP = request.ITP,
                Assurance = request.Assurance,
                RoadTax = request.RoadTax,
                Details = request.Details
            };

            await _repository.InsertAsync(carDetail);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CarDetailsDTO>(carDetail);
        }
    }
}