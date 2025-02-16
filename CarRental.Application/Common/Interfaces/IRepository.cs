using CarRental.Application.Common.Models;
using CarRental.Domain.Common;

namespace CarRental.Application.Common.Interfaces
{
    public interface IRepository
    {
        Task<PaginatedList<T>> GetPaginated<T>(int pageNumber, int pageSize) where T : BaseAuditableEntity;

        IQueryable<T> Get<T>() where T : BaseAuditableEntity;

        Task<T?> GetByIdAsync<T>(Guid guid) where T : BaseAuditableEntity;

        T GetById<T>(Guid guid) where T : BaseAuditableEntity;

        Task<T> InsertAsync<T>(T value) where T : BaseAuditableEntity;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void Update<T>(T value) where T : BaseAuditableEntity;

        void SoftDelete<T>(Guid guid) where T : BaseAuditableEntity;

        void HardDelete<T>(T value) where T : BaseAuditableEntity;
    }
}
