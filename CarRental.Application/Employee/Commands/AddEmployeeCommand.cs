using AutoMapper;
using MediatR;
using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Application.Employees.Dtos;

namespace CarRental.Application.Employees.Commands
{
    public class AddEmployeeCommand : IRequest<EmployeeDTO>
    {
        public string Name { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public DateTime HireDate { get; set; }
        public int HireContract { get; set; }
        public decimal Salary { get; set; }
        public decimal SalaryPerKm { get; set; }
        public string TipEmployees { get; set; } = null!;
        public bool OccupationalMedicine { get; set; }
    }

    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, EmployeeDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddEmployeeCommandHandler(
           IRepository repository,
           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeDTO> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Domain.Entities.Employee
            {
                Guid = Guid.NewGuid(),
                Name = request.Name,
                Birthday = request.Birthday,
                HireDate = request.HireDate,
                HireContract = request.HireContract,
                Salary = request.Salary,
                SalaryPerKm = request.SalaryPerKm,
                TipEmployees = request.TipEmployees,
                OccupationalMedicine = request.OccupationalMedicine
            };

            await _repository.InsertAsync(employee);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<EmployeeDTO>(employee);
        }
    }
}