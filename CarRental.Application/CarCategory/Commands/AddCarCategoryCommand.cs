using AutoMapper;
using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.CarCategories.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.CarCategories.Commands
{
    public class AddCarCategoryCommand : IRequest<CarCategoryDTO>
    {
        public string Description { get; set; } = null!;
    }

    public class AddCarCategoryCommandHandler : IRequestHandler<AddCarCategoryCommand, CarCategoryDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddCarCategoryCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CarCategoryDTO> Handle(AddCarCategoryCommand request, CancellationToken cancellationToken)
        {
            var carCategory = new CarCategory
            {
                Guid = Guid.NewGuid(),
                Description = request.Description
            };

            await _repository.InsertAsync(carCategory);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CarCategoryDTO>(carCategory);
        }
    }
}