using CarRental.Application.Common.Mapping;
using CarRental.Domain.Entities;

namespace CarRental.Application.Employees.Dtos
{
    public class EmployeeDTO : IMapFrom<Employee>
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
}