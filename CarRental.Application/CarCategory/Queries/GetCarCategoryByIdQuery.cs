using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Application.CarCategories.Dtos;

namespace CarRental.Application.CarCategories.Queries
{
    public class GetCarCategoryByIdQuery : IRequest<CarCategoryDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetCarCategoryByIdQueryHandler : IRequestHandler<GetCarCategoryByIdQuery, CarCategoryDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetCarCategoryByIdQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CarCategoryDTO> Handle(GetCarCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new System.ApplicationException("Invalid Id");
            }

            var carCategory = await _repository.GetByIdAsync<CarCategory>(request.Id);

            return carCategory != null ? _mapper.Map<CarCategoryDTO>(carCategory) : throw new NotFoundException(nameof(CarCategory), request.Id);
        }
    }
}