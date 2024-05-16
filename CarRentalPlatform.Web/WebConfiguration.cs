using Microsoft.Extensions.DependencyInjection;

namespace CarRentalPlatform.Web
{
    public static class WebConfiguration
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson();

            return services;
        }
    }
}
