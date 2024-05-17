using CarRentalPlatform.Application.Contracts;
using CarRentalPlatform.Application.Features.Identity.CarAds.Queries.Search;
using CarRentalPlatform.Domain.Models.CarAds;

namespace CarRentalPlatform.Application.Features.Identity.CarAds.Queries
{
    public interface ICarAdRepository : IRepository<CarAd>
    {
        Task<IEnumerable<CarAdListingModel>> GetCarAdListings(
            string? manufacturer = default,
            CancellationToken cancellationToken = default);

        Task<int> Total(CancellationToken cancellationToken = default);
    }
}
