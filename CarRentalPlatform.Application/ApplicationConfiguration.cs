using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace CarRentalPlatform.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services,
                                                             IConfiguration configuration)

        {
            var applicationAssembly = (typeof(ApplicationConfiguration).Assembly);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

            return services.
                Configure<ApplicationSettings>(configuration.GetSection(nameof(ApplicationSettings)), options => options.BindNonPublicProperties = true);
                
                
        }
    }
}
