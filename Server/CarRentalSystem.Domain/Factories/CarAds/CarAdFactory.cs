namespace CarRentalSystem.Domain.Factories.CarAds
{
    using CarRentalSystem.Domain.Exceptions;
    using CarRentalSystem.Domain.Models.CarAds;

    public class CarAdFactory : ICarAdFactory
    {
        private Manufacturer manufacturer = default!;
        private string model = default!;
        private Category category = default!;
        private string imageUrl = default!;
        private decimal pricePerDay = default!;
        private Options options = default!;

        private bool manufacturerSet = false;
        private bool categorySet = false;
        private bool optionsSet = false;

        public ICarAdFactory WithManufacturer(string name)
            => this.WithManufacturer(new Manufacturer(name));

        public ICarAdFactory WithManufacturer(Manufacturer manufacturer)
        {
            this.manufacturer = manufacturer;
            this.manufacturerSet = true;
            return this;
        }

        public ICarAdFactory WithModel(string model)
        {
            this.model = model;
            return this;
        }

        public ICarAdFactory WithCategory(string name, string description)
            => this.WithCategory(new Category(name, description));

        public ICarAdFactory WithCategory(Category category)
        {
            this.category = category;
            this.categorySet = true;
            return this;
        }

        public ICarAdFactory WithImageUrl(string imageUrl)
        {
            this.imageUrl = imageUrl;
            return this;
        }

        public ICarAdFactory WithPricePerDay(decimal pricePerDay)
        {
            this.pricePerDay = pricePerDay;
            return this;
        }

        public ICarAdFactory WithOptions(bool hasClimateControl, int numberOfSeats, TransmissionType transmitionType)
            => this.WithOptions(new Options(hasClimateControl, numberOfSeats, transmitionType));

        public ICarAdFactory WithOptions(Options options)
        {
            this.options = options;
            this.optionsSet = true;
            return this;
        }

        public CarAd Build()
        {
            if (!this.manufacturerSet || !this.categorySet || !this.optionsSet)
            {
                throw new InvalidCarAdException("Manufacturer, category and options must have a value.");
            }

            return new CarAd(
                this.manufacturer,
                this.model,
                this.category,
                this.imageUrl,
                this.pricePerDay,
                this.options,
                true);
        }
    }
}
