namespace CarRentalSystem.Domain.Models.CarAds
{
    using CarRentalSystem.Domain.Common;
    using CarRentalSystem.Domain.Exceptions;
    using static ModelConstants.CarAd;
    using static ModelConstants.Common;

    public class CarAd : Entity<int>, IAggregateRoot
    {
        public CarAd(
            Manufacturer manufacturer,
            string model,
            Category category,
            string imageUrl,
            decimal pricePerDay,
            Options options,
            bool IsAvailable)
        {
            this.Validate(model, imageUrl, pricePerDay);

            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Category = category;
            this.ImageUrl = imageUrl;
            this.PricePerDay = pricePerDay;
            this.Options = options;
            this.IsAvailable = IsAvailable;
        }

        private CarAd(
            string model,
            string imageUrl,
            decimal pricePerDay,
            bool IsAvailable)
        {
            this.Model = model;
            this.ImageUrl = imageUrl;
            this.PricePerDay = pricePerDay;
            this.IsAvailable = IsAvailable;

            this.Manufacturer = default!;
            this.Category = default!;
            this.Options = default!;
        }

        public Manufacturer Manufacturer { get; }

        public string Model { get; }

        public Category Category { get; }

        public string ImageUrl { get; }

        public decimal PricePerDay { get; }

        public Options Options { get; }

        public bool IsAvailable { get; private set; }

        public void ChangeAvailability() => this.IsAvailable = !this.IsAvailable;

        private void Validate(string model, string imageUrl, decimal pricePerDay)
        {
            Guard.ForStringLength<InvalidCarAdException>(
                model,
                MinModelLength,
                MaxModelLength,
                nameof(this.Model));

            Guard.ForValidUrl<InvalidCarAdException>(
                imageUrl,
                nameof(this.ImageUrl));

            Guard.AgainstOutOfRange<InvalidCarAdException>(
                pricePerDay,
                Zero,
                decimal.MaxValue,
                nameof(this.PricePerDay));
        }
    }
}
