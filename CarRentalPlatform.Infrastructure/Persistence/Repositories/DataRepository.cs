using CarRentalPlatform.Application.Contracts;
using CarRentalPlatform.Domain.Common;

namespace CarRentalPlatform.Infrastructure.Persistence.Repositories
{
    internal class DataRepository<TEntity> : IRepository<TEntity>
       where TEntity : class, IAggregateRoot
    {
        private readonly CarRentalDbContext db;

        public DataRepository(CarRentalDbContext db) => this.db = db;

        public IQueryable<TEntity> All() => this.db.Set<TEntity>();

        public Task<int> SaveChanges(CancellationToken cancellationToken = default)
        {
            return this.db.SaveChangesAsync(cancellationToken);
        }
           
    }
}
