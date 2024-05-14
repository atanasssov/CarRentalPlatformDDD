using CarRentalPlatform.Domain.Exceptions;

using FluentAssertions;
using Xunit;

namespace CarRentalPlatform.Domain.Models.CarAds
{
    public class CategorySpecs
    {
        [Fact]
        public void ValidCategoryShouldNotThrowException()
        {
            // Act
            Action act = () => new Category("Valid name", "Valid description text");

            // Assert
            act.Should().NotThrow<InvalidCarAdException>();
        }

        [Fact]
        public void InvalidNameShouldThrowException()
        {
            // Act
            Action act = () => new Category("", "Valid description text");

            // Assert
            act.Should().Throw<InvalidCarAdException>();
        }
    }
}
