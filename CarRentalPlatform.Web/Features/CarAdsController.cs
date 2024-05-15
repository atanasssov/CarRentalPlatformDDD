using Microsoft.AspNetCore.Mvc;

using CarRentalPlatform.Domain.Models.CarAds;
using CarRentalPlatform.Domain.Models.Dealers;


namespace CarRentalPlatform.Web.Features
{
    [ApiController]
    [Route("[controller]")]
    public class CarAdsController : ControllerBase
    {
        private static readonly Dealer Dealer = new Dealer("Dealer", "+12345678");

        [HttpGet]
        public IEnumerable<CarAd> Get()
        {
            return Dealer
            .CarAds
            .Where(c => c.IsAvailable);
        }
       
    }
}
