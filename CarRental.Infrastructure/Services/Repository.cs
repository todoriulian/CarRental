using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces;
using CarRental.Application.Common.Models;
using CarRental.Domain.Common;
using CarRental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Services
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _dataContext = applicationDbContext;
        }

        public async Task<PaginatedList<T>> GetPaginated<T>(int pageNumber, int pageSize) where T : BaseAuditableEntity
        {
            var items = await _dataContext.Set<T>()
                                .AsNoTracking()
                                .Where(x => !x.IsDeleted)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return new PaginatedList<T>(items, items.Count, pageNumber, pageSize);
        }

        public async Task<T?> GetByIdAsync<T>(Guid guid) where T : BaseAuditableEntity
        {
            return await _dataContext.Set<T>()
                                .Where(x => !x.IsDeleted)
                                .FirstOrDefaultAsync(i => i.Guid == guid);
        }

        public async Task<T> InsertAsync<T>(T value) where T : BaseAuditableEntity
        {
            return (await _dataContext.Set<T>().AddAsync(value)).Entity;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var results = await _dataContext.SaveChangesAsync(cancellationToken);
            return results;
        }

        public void Update<T>(T value) where T : BaseAuditableEntity
        {
            _dataContext.Set<T>().Update(value);
            _dataContext.Entry(value).Property(e => e.Guid).IsModified = false;
        }

        public void SoftDelete<T>(Guid guid) where T : BaseAuditableEntity
        {
            var entity = GetById<T>(guid);

            if (entity == null)
            {
                throw new NotFoundException(nameof(T), guid);
            }

            entity.IsDeleted = true;

            Update(entity);
        }

        public void HardDelete<T>(T value) where T : BaseAuditableEntity
        {
            _dataContext.Set<T>().Remove(value);
        }

        public T? GetById<T>(Guid guid) where T : BaseAuditableEntity
        {
            IQueryable<T> query = _dataContext.Set<T>()
                                .Where(x => !x.IsDeleted);
            return query.FirstOrDefault(i => i.Guid == guid);
        }

        public IQueryable<T> Get<T>() where T : BaseAuditableEntity
        {
            return _dataContext.Set<T>()
                                .Where(x => !x.IsDeleted);
        }
    }
}
