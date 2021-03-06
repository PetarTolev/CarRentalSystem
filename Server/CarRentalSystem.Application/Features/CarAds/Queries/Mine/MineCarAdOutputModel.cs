namespace CarRentalSystem.Application.Features.CarAds.Queries.Mine
{
    using AutoMapper;
    using CarRentalSystem.Application.Features.CarAds.Queries.Common;
    using CarRentalSystem.Domain.Models.CarAds;

    public class MineCarAdOutputModel : CarAdOutputModel
    {
        public bool IsAvailable { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<CarAd, MineCarAdOutputModel>()
                .IncludeBase<CarAd, CarAdOutputModel>();
    }
}
