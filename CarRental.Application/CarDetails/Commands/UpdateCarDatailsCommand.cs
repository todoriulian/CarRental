using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.CarDetails.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.CarDetails.Commands
{
    public class UpdateCarDetailCommand : IRequest<CarDetailsDTO>
    {
        public Guid Guid { get; set; }
        public Guid IdCar { get; set; }
        public DateTime ITP { get; set; }
        public DateTime Assurance { get; set; }
        public DateTime RoadTax { get; set; }
        public string Details { get; set; } = null!;
    }

    public class UpdateCarDetailCommandHandler : IRequestHandler<UpdateCarDetailCommand, CarDetailsDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCarDetailCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CarDetailsDTO> Handle(UpdateCarDetailCommand request, CancellationToken cancellationToken)
        {
            var carDetail = await _repository.GetByIdAsync<CarDetail>(request.Guid);
            if (carDetail == null)
            {
                throw new NotFoundException(nameof(CarDetail), request.Guid);
            }

            carDetail.IdCar = request.IdCar;
            carDetail.ITP = request.ITP;
            carDetail.Assurance = request.Assurance;
            carDetail.RoadTax = request.RoadTax;
            carDetail.Details = request.Details;

            _repository.Update(carDetail);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CarDetailsDTO>(carDetail);
        }
    }
}