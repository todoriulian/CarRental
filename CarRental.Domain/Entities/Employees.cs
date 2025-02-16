using CarRental.Domain.Common;
namespace CarRental.Domain.Entities
{
    public class Employees : BaseAuditableEntity
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime HireDate { get; set; }
        public int HireContract { get; set; }
        public decimal Salary { get; set; }
        public decimal SalaryPerKm { get; set; }
        public string TipEmployees { get; set; }
        public bool OccupationalMedicine { get; set; }
    }
}
