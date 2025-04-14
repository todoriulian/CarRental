using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Employees.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.Employees.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeDTO> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new System.ApplicationException("Invalid Id");
            }

            var employee = await _repository.GetByIdAsync<Domain.Entities.Employee>(request.Id);

            return employee != null ? _mapper.Map<EmployeeDTO>(employee) : throw new NotFoundException(nameof(Employee), request.Id);
        }
    }
}