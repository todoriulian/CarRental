using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence
{
    public class CarCategoryConfiguration : IEntityTypeConfiguration<CarCategory>
    {
        public void Configure(EntityTypeBuilder<CarCategory> builder)
        {
            builder.HasKey(category => category.Guid);
            builder.Property(category => category.Guid).ValueGeneratedNever();

            builder.Property(category => category.Description)
                .IsRequired()
                .HasMaxLength(20);

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