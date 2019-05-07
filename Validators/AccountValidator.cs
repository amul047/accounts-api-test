using Accounts.Api.Entities;
using FluentValidation;
using System.Linq;

namespace Accounts.Api.Validators
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator(IValidator<Contact> contactValidator)
        {
            RuleFor(a => a.Name).MaximumLength(100).NotEmpty();
            RuleFor(a => a.OrganisationalUnit).NotNull();
            RuleForEach(a => a.Contacts).SetValidator(contactValidator);
            RuleFor(a => a.Contacts)
                .Must(c => c != null && c.Count(cont => cont.IsBillingContact()) == 1)
                .WithMessage("Exactly 1 billing contact is required");
        }
    }
}