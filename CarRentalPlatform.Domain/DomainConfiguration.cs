using Microsoft.Extensions.DependencyInjection;

using CarRentalPlatform.Domain.Factories;

namespace CarRentalPlatform.Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services
                        .Scan(scan => scan
                        .FromCallingAssembly()
                        .AddClasses(classes => classes.AssignableTo(typeof(IFactory<>)))
                         .AsMatchingInterface()
                         .WithTransientLifetime());
        }
    }
}
