using Microsoft.EntityFrameworkCore;
using CarRentalPlatform.Domain.Models.CarAds;
using CarRentalPlatform.Application.Features.CarAds.Queries;
using CarRentalPlatform.Application.Features.CarAds.Queries.Search;

namespace CarRentalPlatform.Infrastructure.Persistence.Repositories
{
    internal class CarAdRepository : DataRepository<CarAd>, ICarAdRepository
    {
        public CarAdRepository(CarRentalDbContext db)
            : base(db)
        {
        }

        public async Task<IEnumerable<CarAdListingModel>> GetCarAdListings(
            string? manufacturer = default,
            CancellationToken cancellationToken = default)
        {
            var query = this.AllAvailable();

            if (!string.IsNullOrWhiteSpace(manufacturer))
            {
                query = query
                    .Where(car => EF
                        .Functions
                        .Like(car.Manufacturer.Name, $"%{manufacturer}%"));
            }

            return await query
                .Select(car => new CarAdListingModel(
                    car.Id,
                    car.Manufacturer.Name,
                    car.Model,
                    car.ImageUrl,
                    car.Category.Name,
                    car.PricePerDay))
                .ToListAsync(cancellationToken);
        }

        public async Task<int> Total(CancellationToken cancellationToken = default)
        {
            return await this.AllAvailable()
                        .CountAsync(cancellationToken);
        }

        private IQueryable<CarAd> AllAvailable()
        {
            return this.All()
                        .Where(car => car.IsAvailable);
        }
    }
}
