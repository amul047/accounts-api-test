using Accounts.Api.Entities;
using FluentValidation;

namespace Accounts.Api.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.Account).NotNull();
            RuleFor(c => c.FirstName).MaximumLength(200).NotEmpty();
            RuleFor(c => c.LastName).MaximumLength(200).NotEmpty();
            RuleFor(c => c.PhoneNumber).MaximumLength(15);
            RuleFor(c => c.MobileNumber).MaximumLength(15);
            RuleFor(c => c.EmailAddress).MaximumLength(250).NotEmpty().EmailAddress();
            RuleFor(c => c.Role).NotNull();
        }
    }
}