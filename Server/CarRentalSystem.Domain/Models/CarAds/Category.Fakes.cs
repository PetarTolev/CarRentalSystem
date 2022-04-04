namespace CarRentalSystem.Domain.Models.CarAds
{
    using FakeItEasy;
    using System;

    public class CategoryFakes
    {
        public class CategoryDummyFactory : IDummyFactory
        {
            public Priority Priority => Priority.Default;

            public bool CanCreate(Type type) => type == typeof(Category);

            public object? Create(Type type)
                => new Category("Valid category", "Valid description text");
        }
    }
}
