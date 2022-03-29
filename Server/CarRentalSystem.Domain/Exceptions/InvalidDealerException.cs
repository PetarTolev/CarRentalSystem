namespace CarRentalSystem.Domain.Exceptions
{
    internal class InvalidDealerException : BaseDomainException
    {
        public InvalidDealerException()
        {
        }

        public InvalidDealerException(string message)
            => this.Message = message;
    }
}
