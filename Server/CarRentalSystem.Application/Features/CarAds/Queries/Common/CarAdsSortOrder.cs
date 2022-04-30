namespace CarRentalSystem.Application.Features.CarAds.Queries.Common
{
    using CarRentalSystem.Application.Common;
    using CarRentalSystem.Domain.Models.CarAds;
    using System;
    using System.Linq.Expressions;

    public class CarAdsSortOrder : SortOrder<CarAd>
    {
        public CarAdsSortOrder(string? sortBy, string? order)
            : base(sortBy, order)
        {
        }

        public override Expression<Func<CarAd, object>> ToExpression()
            => this.SortBy switch
            {
                "price" => carAd => carAd.PricePerDay,
                "manufacturer" => carAd => carAd.Manufacturer.Name,
                _ => carAd => carAd.Id
            };
    }
}
