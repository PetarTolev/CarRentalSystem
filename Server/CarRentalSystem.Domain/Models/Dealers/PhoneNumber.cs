namespace CarRentalSystem.Domain.Models.Dealers
{
    using CarRentalSystem.Domain.Common;
    using CarRentalSystem.Domain.Exceptions;
    using System.Text.RegularExpressions;
    using static ModelConstants.PhoneNumber;

    public class PhoneNumber : ValueObject
    {
        internal PhoneNumber(string number)
        {
            this.Validate(number);

            this.Number = number;
        }

        public string Number { get; set; }

        public static implicit operator string(PhoneNumber number)
            => number.Number;
        
        public static implicit operator PhoneNumber(string number)
            => new PhoneNumber(number);

        private void Validate(string number)
        {
            Guard.ForStringLength<InvalidPhoneNumberException>(
                number,
                MinPhoneNumberLength,
                MaxPhoneNumberLength,
                nameof(PhoneNumber));

            if (!Regex.IsMatch(number, PhoneNumberRegularExpression))
            {
                throw new InvalidPhoneNumberException("Phone number must start with a '+' and contain only digits afterwards.");
            }
        }
    }
}
