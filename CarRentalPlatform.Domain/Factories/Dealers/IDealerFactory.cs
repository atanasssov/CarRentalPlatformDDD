using CarRentalPlatform.Domain.Models.Dealers;

namespace CarRentalPlatform.Domain.Factories.Dealers
{
    public interface IDealerFactory : IFactory<Dealer>
    {
        IDealerFactory WithName(string name);

        IDealerFactory WithPhoneNumber(string phoneNumber);
    }
}
