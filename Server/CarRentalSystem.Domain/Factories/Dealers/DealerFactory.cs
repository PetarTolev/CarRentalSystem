namespace CarRentalSystem.Domain.Factories.Dealers
{
    using CarRentalSystem.Domain.Models.Dealers;

    class DealerFactory : IDealerFactory
    {
        private string dealerName = default!;
        private string phoneNumber = default!;

        public IDealerFactory WithName(string name)
        {
            this.dealerName = name;
            return this;
        }

        public IDealerFactory WithPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            return this;
        }

        public Dealer Build()
            => new Dealer(this.phoneNumber, this.dealerName);

        public Dealer Build(string phoneNumber, string dealerName)
            => this
                .WithPhoneNumber(phoneNumber)    
                .WithName(dealerName)
                .Build();
    }
}
