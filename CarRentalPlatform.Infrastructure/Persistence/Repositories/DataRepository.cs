using CarRentalPlatform.Application.Contracts;
using CarRentalPlatform.Domain.Common;

namespace CarRentalPlatform.Infrastructure.Persistence.Repositories
{
    internal abstract class DataRepository<TEntity> : IRepository<TEntity>
         where TEntity : class, IAggregateRoot
    {
        private readonly CarRentalDbContext db;

        protected DataRepository(CarRentalDbContext db)
        {
            this.db = db;
        }

        protected IQueryable<TEntity> All()
        {
            return this.db.Set<TEntity>();
        }
    }
}
