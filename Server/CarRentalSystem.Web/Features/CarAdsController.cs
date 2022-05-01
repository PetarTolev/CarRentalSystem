namespace CarRentalSystem.Web.Features
{
    using CarRentalSystem.Application.Features.CarAds.Commands.ChangeAvailability;
    using CarRentalSystem.Application.Features.CarAds.Commands.Create;
    using CarRentalSystem.Application.Features.CarAds.Queries.Categories;
    using CarRentalSystem.Application.Features.CarAds.Queries.Mine;
    using CarRentalSystem.Application.Features.CarAds.Queries.Search;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CarAdsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchCarAdsOutputModel>> Search(
            [FromQuery] SearchCarAdsQuery query)
            => await this.Send(query);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateCarAdOutputModel>> Create(
            CreateCarAdCommand command)
            => await this.Send(command);

        [HttpGet]
        [Route(nameof(Categories))]
        public async Task<ActionResult<IEnumerable<GetCarAdCategoryOutputModel>>> Categories(
            [FromQuery] GetCarAdCategoriesQuery query)
            => await this.Send(query);

        [HttpGet]
        [Authorize]
        [Route(nameof(Mine))]
        public async Task<ActionResult<MineCarAdsOutputModel>> Mine(
            [FromQuery] MineCarAdsQuery query)
            => await this.Send(query);

        [HttpPut]
        [Authorize]
        [Route(Id + PathSeparator + nameof(ChangeAvailability))]
        public async Task<ActionResult> ChangeAvailability(
            [FromRoute] ChangeAvailabilityCommand command)
            => await this.Send(command);
    }
}
