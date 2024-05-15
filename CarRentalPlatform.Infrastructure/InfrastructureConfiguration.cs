using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using CarRentalPlatform.Infrastructure.Persistence;
using CarRentalPlatform.Application.Contracts;
using CarRentalPlatform.Infrastructure.Persistence.Repositories;

namespace CarRentalPlatform.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            return services.AddDbContext<CarRentalDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(CarRentalDbContext).Assembly.FullName)))
                .AddTransient<IInitializer, CarRentalDbInitializer>()
                .AddTransient(typeof(IRepository<>),typeof(DataRepository<>));
        }
    }
}
