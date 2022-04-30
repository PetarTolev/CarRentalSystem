namespace CarRentalSystem.Domain.Specification.Dealers
{
    using CarRentalSystem.Domain.Models.Dealers;
    using CarRentalSystem.Domain.Specifications;
    using System;
    using System.Linq.Expressions;

    public class DealerByIdSpecification : Specification<Dealer>
    {
        private readonly int? id;

        public DealerByIdSpecification(int? id) 
            => this.id = id;

        protected override bool Include => this.id.HasValue;

        public override Expression<Func<Dealer, bool>> ToExpression()
            => dealer => dealer.Id == this.id;
    }
}
