using AutoMapper;
using MediatR;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Employees.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application.Employees.Commands
{
    public class UpdateEmployeeCommand : IRequest<EmployeeDTO>
    {
        public Guid Guid { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public DateTime HireDate { get; set; }
        public int HireContract { get; set; }
        public decimal Salary { get; set; }
        public decimal SalaryPerKm { get; set; }
        public string TipEmployees { get; set; } = null!;
        public bool OccupationalMedicine { get; set; }
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeDTO> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync<Employee>(request.Guid);
            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.Guid);
            }

            employee.Name = request.Name;
            employee.Birthday = request.Birthday;
            employee.HireDate = request.HireDate;
            employee.HireContract = request.HireContract;
            employee.Salary = request.Salary;
            employee.SalaryPerKm = request.SalaryPerKm;
            employee.TipEmployees = request.TipEmployees;
            employee.OccupationalMedicine = request.OccupationalMedicine;

            _repository.Update(employee);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<EmployeeDTO>(employee);
        }
    }
}