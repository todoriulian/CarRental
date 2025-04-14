using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(client => client.Guid);
            builder.Property(client => client.Guid).ValueGeneratedNever();

            builder.Property(client => client.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(client => client.BirthDate)
                .IsRequired();

            builder.Property(client => client.Address)
                .IsRequired()
                .HasMaxLength(50);


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