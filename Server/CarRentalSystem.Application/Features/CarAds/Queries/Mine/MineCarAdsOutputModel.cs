namespace CarRentalSystem.Application.Features.CarAds.Queries.Mine
{
    using CarRentalSystem.Application.Features.CarAds.Queries.Common;
    using System.Collections.Generic;

    public class MineCarAdsOutputModel : CarAdsOutputModel<CarAdOutputModel>
    {
        internal MineCarAdsOutputModel(
            IEnumerable<CarAdOutputModel> carAds,
            int page,
            int totalPages)
            : base(carAds, page, totalPages)
        {
        }
    }
}
