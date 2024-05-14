using CarRentalPlatform.Domain.Common;
using CarRentalPlatform.Domain.Exceptions;

using static CarRentalPlatform.Domain.Models.ModelConstants.Common;

namespace CarRentalPlatform.Domain.Models.CarAds
{
    public class Manufacturer : Entity<int>
    {
        internal Manufacturer(string name)
        {
            this.Validate(name);

            this.Name = name;
        }

        public string Name { get; }

        public void Validate(string name)
            => Guard.ForStringLength<InvalidCarAdException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
