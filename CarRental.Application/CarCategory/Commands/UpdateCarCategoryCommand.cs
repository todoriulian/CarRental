using AutoMapper;
using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.CarCategories.Dtos;
using CarRental.Application.Common.Exceptions;
using CarRental.Domain.Entities;

namespace CarRental.Application.CarCategories.Commands
{
    public class UpdateCarCategoryCommand : IRequest<CarCategoryDTO>
    {
        public Guid Guid { get; set; }
        public string Description { get; set; } = null!;
    }

    public class UpdateCarCategoryCommandHandler : IRequestHandler<UpdateCarCategoryCommand, CarCategoryDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCarCategoryCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CarCategoryDTO> Handle(UpdateCarCategoryCommand request, CancellationToken cancellationToken)
        {
            var carCategory = await _repository.GetByIdAsync<Domain.Entities.CarCategory>(request.Guid);
            if (carCategory == null)
            {
                throw new NotFoundException(nameof(CarCategory), request.Guid);
            }

            carCategory.Description = request.Description;

            _repository.Update(carCategory);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CarCategoryDTO>(carCategory);
        }
    }
}