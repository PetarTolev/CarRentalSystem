namespace CarRentalSystem.Application.Features.CarAds.Queries.Mine
{
    using CarRentalSystem.Application.Features.CarAds.Queries.Common;
    using System.Collections.Generic;

    public class MineCarAdsOutputModel : CarAdsOutputModel<MineCarAdOutputModel>
    {
        internal MineCarAdsOutputModel(
            IEnumerable<MineCarAdOutputModel> carAds,
            int page,
            int totalPages)
            : base(carAds, page, totalPages)
        {
        }
    }
}
