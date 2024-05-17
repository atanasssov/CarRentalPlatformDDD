using CarRentalPlatform.Application.Features.CarAds.Queries;
using MediatR;

namespace CarRentalPlatform.Application.Features.CarAds.Queries.Search
{
    public class SearchCarAdsQuery : IRequest<SearchCarAdsOutputModel>
    {
        public string? Manufacturer { get; set; }

        public class SearchCarAdsQueryHandler : IRequestHandler<SearchCarAdsQuery, SearchCarAdsOutputModel>
        {
            private readonly ICarAdRepository carAdRepository;

            public SearchCarAdsQueryHandler(ICarAdRepository carAdRepository)
                => this.carAdRepository = carAdRepository;

            public async Task<SearchCarAdsOutputModel> Handle(
                SearchCarAdsQuery request,
                CancellationToken cancellationToken)
            {
                var carAdListings = await carAdRepository.GetCarAdListings(
                    request.Manufacturer,
                    cancellationToken);

                var totalCarAds = await carAdRepository.Total(cancellationToken);

                return new SearchCarAdsOutputModel(carAdListings, totalCarAds);
            }
        }
    }
}
