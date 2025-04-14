using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CarRental.Domain.Common;

namespace CarRental.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars => Set<Car>();
        public DbSet<CarCategory> CarCategories => Set<CarCategory>();
        public DbSet<CarDetail> CarsDetails => Set<CarDetail>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<DrivingLicenceCategory> DrivingLicenceCatgories => Set<DrivingLicenceCategory>();
        public DbSet<Client> Client => Set<Client>();
        public DbSet<DrivingLicenceCategoryDriver> DrivingLicenceCategoryDrivers => Set<DrivingLicenceCategoryDriver>();
        public DbSet<DriverHistory> DriverHistories => Set<DriverHistory>();
        public DbSet<Rent> Rent => Set<Rent>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<PriceHistory> PriceHistories => Set<PriceHistory>();
        public DbSet<RentHistory> RentHistories => Set<RentHistory>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.UtcNow;
                        entry.Entity.IsDeleted = false;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.Deleted = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}