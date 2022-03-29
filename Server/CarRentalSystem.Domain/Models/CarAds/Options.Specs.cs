namespace CarRentalSystem.Domain.Models.CarAds
{
    using CarRentalSystem.Domain.Exceptions;
    using FluentAssertions;
    using System;
    using Xunit;

    public class OptionsSpecs
    {
        [Fact]
        public void InvalidNumberOfSeatsShouldThrowException()
        {
            Action options = () => new Options(true, 1, TransmitionType.Automatic);

            options.Should().Throw<InvalidCarAdException>();
        }
    }
}
