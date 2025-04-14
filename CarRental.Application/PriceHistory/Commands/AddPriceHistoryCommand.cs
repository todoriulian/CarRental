using AutoMapper;
using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Application.PriceHistory.Dtos;

namespace CarRental.Application.PriceHistory.Commands
{
    public class AddPriceHistoryCommand : IRequest<PriceHistoryDTO>
    {
        public Guid IdCar { get; set; }
        public Guid IdCarCategory { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public decimal Price { get; set; }
    }

    public class AddPriceHistoryCommandHandler : IRequestHandler<AddPriceHistoryCommand, PriceHistoryDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddPriceHistoryCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PriceHistoryDTO> Handle(AddPriceHistoryCommand request, CancellationToken cancellationToken)
        {
            var priceHistory = new Domain.Entities.PriceHistory
            {
                Guid = Guid.NewGuid(),
                IdCar = request.IdCar,
                IdCarCategory = request.IdCarCategory,
                StartDate = request.StartDate,
                FinalDate = request.FinalDate,
                Price = request.Price
            };

            await _repository.InsertAsync(priceHistory);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<PriceHistoryDTO>(priceHistory);
        }
    }
}