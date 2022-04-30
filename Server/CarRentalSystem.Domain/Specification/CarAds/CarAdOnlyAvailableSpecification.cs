namespace CarRentalSystem.Domain.Specification.CarAds
{
    using CarRentalSystem.Domain.Models.CarAds;
    using CarRentalSystem.Domain.Specifications;
    using System;
    using System.Linq.Expressions;

    public class CarAdOnlyAvailableSpecification : Specification<CarAd>
    {
        private readonly bool onlyAvailable;

        public CarAdOnlyAvailableSpecification(bool onlyAvailable) 
            => this.onlyAvailable = onlyAvailable;

        public override Expression<Func<CarAd, bool>> ToExpression()
        {
            if (this.onlyAvailable)
            {
                return carAd => carAd.IsAvailable;
            }

            return carAd => true;
        }
    }
}
