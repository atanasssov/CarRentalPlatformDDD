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
       
        [HttpGet]
        public async Task<ActionResult<SearchCarAdsOutputModel>> Get(
            [FromQuery] SearchCarAdsQuery query)
        {
            return await this.Send(query);
        }
    }
}
