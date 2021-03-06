namespace CarRentalSystem.Domain.Models.CarAds
{
    using Bogus;
    using FakeItEasy;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarAdFakes
    {
        public class CarAdDummyFactory : IDummyFactory
        {
            public Priority Priority => Priority.Default;

            public bool CanCreate(Type type) => type == typeof(CarAd);

            public object? Create(Type type) => Data.GetCarAd();
        }

        public static class Data
        {
            public static IEnumerable<CarAd> GetCarAds(int count = 10)
                => Enumerable
                    .Range(1, count)
                    .Select(i => GetCarAd(i))
                    .Concat(Enumerable
                        .Range(count + 1, count + 2)
                        .Select(i => GetCarAd(i, false)))
                    .ToList();

            public static CarAd GetCarAd(int id = 1, bool isAvailable = true)
                => new Faker<CarAd>()
                    .CustomInstantiator(f => new CarAd(
                        new Manufacturer($"Manufacturer{id}"),
                        f.Lorem.Letter(10),
                        A.Dummy<Category>(),
                        f.Image.PicsumUrl(),
                        f.Random.Number(100, 200),
                        A.Dummy<Options>(),
                        isAvailable))
                    .Generate();
        }
    }
}
