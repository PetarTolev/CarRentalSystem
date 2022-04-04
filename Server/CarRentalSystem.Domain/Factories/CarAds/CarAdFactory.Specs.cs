namespace CarRentalSystem.Domain.Factories.CarAds
{
    using CarRentalSystem.Domain.Exceptions;
    using CarRentalSystem.Domain.Models.CarAds;
    using FluentAssertions;
    using System;
    using Xunit;

    public class CarAdFactorySpecs
    {
        [Fact]
        public void BuildShouldThrowExceptionIfManufacturerIsMissing()
        {
            var factory = new CarAdFactory();

            Action act = () => factory
                .WithCategory("TestCategory", "TestDescription")
                .WithOptions(true, 2, TransmissionType.Automatic)
                .Build();

            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfCategoryIsMissing()
        {
            var factory = new CarAdFactory();

            Action act = () => factory
                .WithManufacturer("TestManufacturer")
                .WithOptions(true, 2, TransmissionType.Automatic)
                .Build();

            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfOptionsIsMissing()
        {
            var factory = new CarAdFactory();

            Action act = () => factory
                .WithManufacturer("TestManufacturer")
                .WithCategory("TestCategory", "TestCategoryDescription")
                .Build();

            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void BuildShouldCreateCarAdIfEveryPropertyIsSet()
        {
            var factory = new CarAdFactory();

            var carAd = factory
                .WithManufacturer("TestManufacturer")
                .WithCategory("TestCategory", "TestCategoryDescription")
                .WithImageUrl("http://test.image.url")
                .WithModel("TestModel")
                .WithPricePerDay(10)
                .WithOptions(true, 2, TransmissionType.Automatic)
                .Build();

            carAd.Should().NotBeNull();
        }
    }
}
