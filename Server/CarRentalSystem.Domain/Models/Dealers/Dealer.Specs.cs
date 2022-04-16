namespace CarRentalSystem.Domain.Models.Dealers
{
    using CarRentalSystem.Domain.Exceptions;
    using CarRentalSystem.Domain.Models.CarAds;
    using FakeItEasy;
    using FluentAssertions;
    using System;
    using Xunit;

    public class DealerSpecs
    {
        [Fact]
        public void AddCarAdShouldSaveCarAd()
        {
            var dealer = new Dealer("+123123123123", "Valid name");
            var carAd = A.Dummy<CarAd>();

            dealer.AddCarAd(carAd);

            dealer.CarAds.Should().Contain(carAd);
        }

        [Fact]
        public void InvalidNameLengthShouldThrowException()
        {
            Action dealer = () => new Dealer("+123123123123", "");

            dealer.Should().Throw<InvalidDealerException>();
        }
    }
}
