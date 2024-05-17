using CarRentalPlatform.Domain.Common;

namespace CarRentalPlatform.Application.Contracts
{
    public interface IRepository<out TEntity>
        where TEntity : IAggregateRoot
    {

    }
}
