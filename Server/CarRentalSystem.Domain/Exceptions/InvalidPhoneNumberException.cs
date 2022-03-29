namespace CarRentalSystem.Domain.Exceptions
{
    internal class InvalidPhoneNumberException : BaseDomainException
    {
        public InvalidPhoneNumberException()
        {
        }

        public InvalidPhoneNumberException(string message)
            => this.Message = message;
    }
}
