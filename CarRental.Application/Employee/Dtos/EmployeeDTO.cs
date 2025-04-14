namespace CarRental.Application.Employees.Dtos
{
    public class EmployeeDTO
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