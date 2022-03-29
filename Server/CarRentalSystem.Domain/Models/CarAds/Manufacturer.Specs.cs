namespace CarRentalSystem.Domain.Models.CarAds
{
    using CarRentalSystem.Domain.Exceptions;
    using FluentAssertions;
    using System;
    using Xunit;

    public class ManufacturerSpecs
    {
        [Fact]
        public void InvalidNameLengthShouldThrowException()
        {
            Action shortName = () => new Manufacturer("");
            Action longName = () => new Manufacturer("Too long manufacturer name");

            shortName.Should().Throw<InvalidCarAdException>();
            longName.Should().Throw<InvalidCarAdException>();
        }
    }
}
