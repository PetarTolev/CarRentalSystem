namespace CarRentalSystem.Domain.Models.CarAds
{
    using CarRentalSystem.Domain.Exceptions;
    using FluentAssertions;
    using System;
    using Xunit;

    public class CategorySpecs
    {
        [Fact]
        public void ValidCategoryShouldNotThrowException()
        {
            Action act = () => new Category("Valid name", "Valid description text");

            act.Should().NotThrow<InvalidCarAdException>();
        }

        [Fact]
        public void InvalidCategoryShouldThrowException()
        {
            Action act = () => new Category("", "Valid description");

            act.Should().Throw<InvalidCarAdException>();
        }
    }
}
