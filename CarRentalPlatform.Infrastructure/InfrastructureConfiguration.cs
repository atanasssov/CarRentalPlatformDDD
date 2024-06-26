﻿using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using CarRentalPlatform.Infrastructure.Persistence;
using CarRentalPlatform.Application.Contracts;
using CarRentalPlatform.Infrastructure.Persistence.Repositories;
using CarRentalPlatform.Infrastructure.Identity;
using CarRentalPlatform.Application;


namespace CarRentalPlatform.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                        .AddDatabase(configuration)
                        .AddRepositories()
                        .AddIdentity(configuration);
        }

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                        .AddDbContext<CarRentalDbContext>(options => options
                            .UseSqlServer(
                                configuration.GetConnectionString("DefaultConnection"),
                                b => b.MigrationsAssembly(typeof(CarRentalDbContext)
                                    .Assembly.FullName)))
                        .AddTransient<IInitializer, CarRentalDbInitializer>();
        }

        internal static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                        .Scan(scan => scan
                            .FromCallingAssembly()
                            .AddClasses(classes => classes
                                .AssignableTo(typeof(IRepository<>)))
                            .AsMatchingInterface()
                            .WithTransientLifetime());
        }

        private static IServiceCollection AddIdentity(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<CarRentalDbContext>();

            var secret = configuration
                .GetSection(nameof(ApplicationSettings))
                .GetValue<string>(nameof(ApplicationSettings.Secret));

            var key = Encoding.ASCII.GetBytes(secret);

            services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddTransient<IIdentity, IdentityService>();

            return services;
        }
    }
}
