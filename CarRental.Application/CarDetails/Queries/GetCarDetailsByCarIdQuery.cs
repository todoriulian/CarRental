using AutoMapper;
using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.CarDetails.Dtos;
using CarRental.Domain.Entities;
using CarRental.Application.Common.Exceptions;

namespace CarRental.Application.CarDetails.Queries
{
    public class GetCarDetailsByCarIdQuery : IRequest<List<CarDetailsDTO>>
    {
        public Guid CarId { get; set; }
    }

    public class GetCarDetailsByCarIdQueryHandler : IRequestHandler<GetCarDetailsByCarIdQuery, List<CarDetailsDTO>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetCarDetailsByCarIdQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CarDetailsDTO>> Handle(GetCarDetailsByCarIdQuery request, CancellationToken cancellationToken)
        {
            var carDetailsa = _repository.Get<CarDetail>().Where(cd => cd.IdCar == request.CarId).ToList();

            return _mapper.Map<List<CarDetailsDTO>>(carDetailsa);
        }
    }
}