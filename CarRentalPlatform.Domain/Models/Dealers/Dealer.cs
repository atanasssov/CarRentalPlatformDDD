using CarRentalPlatform.Domain.Common;
using CarRentalPlatform.Domain.Exceptions;
using CarRentalPlatform.Domain.Models.CarAds;

using static CarRentalPlatform.Domain.Models.ModelConstants.Common;

namespace CarRentalPlatform.Domain.Models.Dealers
{
    public class Dealer : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<CarAd> carAds;

        public Dealer(string name, string phoneNumber)
        {
            this.Validate(name);

            this.Name = name;
            this.PhoneNumber = phoneNumber;

            this.carAds = new HashSet<CarAd>();
        }

        public string Name { get; }

        public PhoneNumber PhoneNumber { get; }

        public IReadOnlyCollection<CarAd> CarAds => this.carAds.ToList().AsReadOnly();

        public void AddCarAd(CarAd carAd) => this.carAds.Add(carAd);

        private void Validate(string name)
            => Guard.ForStringLength<InvalidDealerException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
