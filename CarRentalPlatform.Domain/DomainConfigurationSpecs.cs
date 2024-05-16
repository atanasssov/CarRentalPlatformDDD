using Microsoft.Extensions.DependencyInjection;

using CarRentalPlatform.Domain.Factories.CarAds;
using CarRentalPlatform.Domain.Factories.Dealers;

using Xunit;
using FluentAssertions;

namespace CarRentalPlatform.Domain
{
    public class DomainConfigurationSpecs
    {
        [Fact]
        public void AddDomainShouldRegisterFactories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            var services = serviceCollection
                .AddDomain()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IDealerFactory>()
                .Should()
                .NotBeNull();

            services
                .GetService<ICarAdFactory>()
                .Should()
                .NotBeNull();
        }
    }
}
