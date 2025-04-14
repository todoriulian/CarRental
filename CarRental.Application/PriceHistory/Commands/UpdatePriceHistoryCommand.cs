using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.PriceHistory.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.PriceHistory.Commands
{
    public class UpdatePriceHistoryCommand : IRequest<PriceHistoryDTO>
    {
        public Guid Guid { get; set; }
        public Guid IdCar { get; set; }
        public Guid IdCarCategory { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public decimal Price { get; set; }
    }

    public class UpdatePriceHistoryCommandHandler : IRequestHandler<UpdatePriceHistoryCommand, PriceHistoryDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePriceHistoryCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PriceHistoryDTO> Handle(UpdatePriceHistoryCommand request, CancellationToken cancellationToken)
        {
            var priceHistory = await _repository.GetByIdAsync<Domain.Entities.PriceHistory>(request.Guid);
            if (priceHistory == null)
            {
                throw new NotFoundException(nameof(PriceHistory), request.Guid);
            }

            priceHistory.IdCar = request.IdCar;
            priceHistory.IdCarCategory = request.IdCarCategory;
            priceHistory.StartDate = request.StartDate;
            priceHistory.FinalDate = request.FinalDate;
            priceHistory.Price = request.Price;

            _repository.Update(priceHistory);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<PriceHistoryDTO>(priceHistory);
        }
    }
}