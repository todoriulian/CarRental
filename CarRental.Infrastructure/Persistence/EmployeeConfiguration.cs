using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(employee => employee.Guid);
            builder.Property(employee => employee.Guid).ValueGeneratedNever();

            builder.Property(employee => employee.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(employee => employee.Birthday)
                .IsRequired();

            builder.Property(employee => employee.HireDate)
                .IsRequired();

            builder.Property(employee => employee.HireContract)
                .IsRequired();

            builder.Property(employee => employee.Salary)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(employee => employee.SalaryPerKm)
                .IsRequired()
                .HasColumnType("decimal(3,2)");

            builder.Property(employee => employee.TipEmployees)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(employee => employee.OccupationalMedicine)
                .IsRequired();


            // Configure BaseAuditableEntity properties
            builder.Property(carDetail => carDetail.Created)
                .IsRequired();

            builder.Property(carDetail => carDetail.LastModified);

            builder.Property(carDetail => carDetail.IsDeleted)
                .IsRequired();

            builder.Property(carDetail => carDetail.Deleted);
        }
    }
}