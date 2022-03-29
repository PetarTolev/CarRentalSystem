namespace CarRentalSystem.Domain.Models.Dealers
{
    using CarRentalSystem.Domain.Common;
    using CarRentalSystem.Domain.Exceptions;
    using CarRentalSystem.Domain.Models.CarAds;
    using System.Collections.Generic;
    using System.Linq;
    using static ModelConstants.Common;

    public class Dealer : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<CarAd> carAds;

        public Dealer(string phoneNumber, string name)
        {
            this.Validate(name);

            this.PhoneNumber = phoneNumber;
            this.Name = name;

            this.carAds = new HashSet<CarAd>();
        }

        public string Name { get; }

        public PhoneNumber PhoneNumber { get; }

        public IReadOnlyCollection<CarAd> CarAds
            => this.carAds.ToList().AsReadOnly();

        public void AddCarAd(CarAd carAd)
            => this.carAds.Add(carAd);

        private void Validate(string name)
            => Guard.ForStringLength<InvalidDealerException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
