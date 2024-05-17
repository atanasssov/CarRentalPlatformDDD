using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using CarRentalPlatform.Domain.Models.CarAds;
using CarRentalPlatform.Application.Contracts;
using CarRentalPlatform.Application;
using CarRentalPlatform.Application.Features.Identity.CarAds.Queries.Search;
using MediatR;

namespace CarRentalPlatform.Web.Features
{
    [ApiController]
    [Route("[controller]")]
    public class CarAdsController : ApiController
    {
        private readonly IRepository<CarAd> carAds;
        private readonly IOptions<ApplicationSettings> settings;

        public CarAdsController(IRepository<CarAd> carAds,
                                IOptions<ApplicationSettings> settings,
                                IMediator mediator)
        {
            this.carAds = carAds;
            this.settings = settings;
         
        }

        [HttpGet]
        public async Task<ActionResult<SearchCarAdsOutputModel>> Get(
            [FromQuery] SearchCarAdsQuery query)
        {
            return await this.Send(query);
        }
    }
}
