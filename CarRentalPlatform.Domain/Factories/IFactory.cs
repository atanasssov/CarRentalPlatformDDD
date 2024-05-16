using CarRentalPlatform.Domain.Common;

namespace CarRentalPlatform.Domain.Factories
{
    public interface IFactory<out TEntity> where TEntity : IAggregateRoot
    {
        TEntity Build();
    }
}
