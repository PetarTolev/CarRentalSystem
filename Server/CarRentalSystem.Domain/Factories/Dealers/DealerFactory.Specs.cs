namespace CarRentalSystem.Domain.Factories.Dealers
{
    using FluentAssertions;
    using Xunit;

    public class DealerFactorySpecs
    {
        [Fact]
        public void BuildShouldCreateDealerIfEveryPropertyIsSet()
        {
            var factory = new DealerFactory();

            var dealer = factory
                .WithName("Valid Name")
                .WithPhoneNumber("+123123123123")
                .Build();

            dealer.Should().NotBeNull();
        }
    }
}
