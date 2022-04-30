namespace CarRentalSystem.Application.Features.CarAds.Queries.Search
{
    using CarRentalSystem.Application.Features.CarAds.Queries.Common;
    using System.Collections.Generic;

    public class SearchCarAdsOutputModel : CarAdsOutputModel<CarAdOutputModel>
    {
        public SearchCarAdsOutputModel(
            IEnumerable<CarAdOutputModel> carAds,
            int page,
            int totalPages)
            : base(carAds, page, totalPages)
        {
        }
    }
}
