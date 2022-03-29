namespace CarRentalSystem.Domain.Models.CarAds
{
    using FakeItEasy;
    using System;

    public class CarAdFakes
    {
        public class CarAdDummyFactory : IDummyFactory
        {
            public Priority Priority => Priority.Default;

            public bool CanCreate(Type type) => true;

            public object? Create(Type type)
                => new CarAd(
                    new Manufacturer("Valid Manufacturer"),
                    "Valid model",
                    new Category("Valid name", "Valid description text"),
                    "https://valid.test",
                    10,
                    new Options(true, 4, TransmitionType.Automatic),
                    true);
        }
    }
}
