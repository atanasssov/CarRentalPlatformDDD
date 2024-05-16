using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using CarRentalPlatform.Domain.Models.CarAds;
using CarRentalPlatform.Application.Contracts;
using CarRentalPlatform.Application;



namespace CarRentalPlatform.Web.Features
{
    [ApiController]
    [Route("[controller]")]
    public class CarAdsController : ControllerBase
    {
        private readonly IRepository<CarAd> carAds;
        private readonly IOptions<ApplicationSettings> settings;

        public CarAdsController(IRepository<CarAd> carAds,
                                IOptions<ApplicationSettings> settings)
        {
            this.carAds = carAds;
            this.settings = settings;
        }

        [HttpGet]
        public object Get()
        {
            return new
            {
                Settings = this.settings,
                CarAds = this.carAds
                .All()
                .Where(c => c.IsAvailable)
                .ToList()
            };
        }
    }
}
