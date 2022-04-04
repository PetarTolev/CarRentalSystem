namespace CarRentalSystem.Domain.Models.CarAds
{
    using CarRentalSystem.Domain.Exceptions;
    using FakeItEasy;
    using FluentAssertions;
    using System;
    using Xunit;

    public class CarAdSpecs
    {
        [Fact]
        public void ChangeAvailabilityShouldMutateIsAvailable()
        {
            var carAd = A.Dummy<CarAd>();

            carAd.ChangeAvailability();

            carAd.IsAvailable.Should().BeFalse();
        }

        [Fact]
        public void InvalidModelLengthShouldThrowException()
        {
            Action act = () => new CarAd(
                new Manufacturer("Valid Manufacturer"),
                "",
                new Category("Valid name", "Valid description text"),
                "https://valid.test",
                10,
                new Options(true, 4, TransmissionType.Automatic),
                true);

            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void InvalidImageUrlShouldThrowException()
        {
            Action act = () => new CarAd(
                new Manufacturer("Valid Manufacturer"),
                "Valid model",
                new Category("Valid name", "Valid description text"),
                "",
                10,
                new Options(true, 4, TransmissionType.Automatic),
                true);

            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void InvalidPricePerDayShouldThrowException()
        {
            Action act = () => new CarAd(
                new Manufacturer("Valid Manufacturer"),
                "Valid model",
                new Category("Valid name", "Valid description text"),
                "https://valid.test",
                -1,
                new Options(true, 4, TransmissionType.Automatic),
                true);

            act.Should().Throw<InvalidCarAdException>();
        }
    }
}
