using CarRentalPlatform.Domain.Common;
using CarRentalPlatform.Domain.Exceptions;

using static CarRentalPlatform.Domain.Models.ModelConstants.Common;
using static CarRentalPlatform.Domain.Models.ModelConstants.Category;

namespace CarRentalPlatform.Domain.Models.CarAds
{
    public class Category : Entity<int>
    {
        internal Category(string name, string description)
        {
            this.Validate(name, description);

            this.Name = name;
            this.Description = description;
        }

        public string Name { get; }

        public string Description { get; }

        private void Validate(string name, string description)
        {
            Guard.ForStringLength<InvalidCarAdException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

            Guard.ForStringLength<InvalidCarAdException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(this.Description));
        }
    }
}
