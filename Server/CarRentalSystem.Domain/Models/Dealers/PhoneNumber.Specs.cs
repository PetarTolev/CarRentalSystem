namespace CarRentalSystem.Domain.Models.Dealers
{
    using CarRentalSystem.Domain.Exceptions;
    using FluentAssertions;
    using System;
    using Xunit;

    public class PhoneNumberSpecs
    {
        [Fact]
        public void NumberWithoutPlusSignShouldThrowException()
        {
            Action phoneNumber = () => new PhoneNumber("123123123");

            phoneNumber.Should().Throw<InvalidPhoneNumberException>();
        }

        [Fact]
        public void InvalidNumberLengthShouldThrowException()
        {
            Action phoneNumber = () => new PhoneNumber("+123");

            phoneNumber.Should().Throw<InvalidPhoneNumberException>();
        }
    }
}
