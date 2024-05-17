using Microsoft.AspNetCore.Mvc;

using CarRentalPlatform.Application.Features.CarAds.Queries.Search;

namespace CarRentalPlatform.Web.Features
{
    [ApiController]
    [Route("[controller]")]
    public class CarAdsController : ApiController
    {
       
        [HttpGet]
        public async Task<ActionResult<SearchCarAdsOutputModel>> Get(
            [FromQuery] SearchCarAdsQuery query)
        {
            return await this.Send(query);
        }
    }
}
