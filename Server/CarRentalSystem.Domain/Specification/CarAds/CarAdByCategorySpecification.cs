namespace CarRentalSystem.Domain.Specification.CarAds
{
    using CarRentalSystem.Domain.Models.CarAds;
    using CarRentalSystem.Domain.Specifications;
    using System;
    using System.Linq.Expressions;

    public class CarAdByCategorySpecification : Specification<CarAd>
    {
        private readonly int? category;

        public CarAdByCategorySpecification(int? category)
            => this.category = category;

        protected override bool Include => this.category != null;   

        public override Expression<Func<CarAd, bool>> ToExpression()
            => carAd => carAd.Category.Id == this.category;
    }
}
