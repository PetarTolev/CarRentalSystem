namespace CarRentalSystem.Web.Features
{
    using CarRentalSystem.Application.Features.CarAds.Queries.Search;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CarAdsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchCarAdsOutputModel>> Get(
            [FromQuery] SearchCarAdsQuery query)
            => await this.Mediator.Send(query);
    }
}
