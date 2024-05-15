using Microsoft.AspNetCore.Mvc;

using CarRentalPlatform.Domain.Models.CarAds;
using CarRentalPlatform.Application.Contracts;


namespace CarRentalPlatform.Web.Features
{
    [ApiController]
    [Route("[controller]")]
    public class CarAdsController : ControllerBase
    {
        private readonly IRepository<CarAd> carAds;

        public CarAdsController(IRepository<CarAd> carAds)
        {
            this.carAds = carAds;
        }

        [HttpGet]
        public IEnumerable<CarAd> Get()
        {
            return this.carAds
            .All()
            .Where(c => c.IsAvailable);
        }
    }
}
