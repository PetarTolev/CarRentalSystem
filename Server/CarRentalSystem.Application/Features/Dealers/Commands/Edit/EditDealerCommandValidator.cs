namespace CarRentalSystem.Application.Features.Dealers.Commands.Edit
{
    using FluentValidation;
    using static CarRentalSystem.Domain.Models.ModelConstants.Common;
    using static CarRentalSystem.Domain.Models.ModelConstants.PhoneNumber;

    public class EditDealerCommandValidator : AbstractValidator<EditDealerCommand>
    {
        public EditDealerCommandValidator()
        {
            this
                .RuleFor(d => d.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this
                .RuleFor(d => d.PhoneNumber)
                .MinimumLength(MinPhoneNumberLength)
                .MaximumLength(MaxPhoneNumberLength)
                .Matches(PhoneNumberRegularExpression)
                .NotEmpty();
        }
    }
}
