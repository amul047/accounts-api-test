using Accounts.Api.Entities;
using FluentValidation;
using System.Linq;

namespace Accounts.Api.Validators
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator(IValidator<Contact> contactValidator)
        {
            RuleFor(a => a).Must(account =>
                string.Equals(account.InvoiceMedium, "Text") && account.Contacts.Any(c => c.IsBillingContact() && !string.IsNullOrWhiteSpace(c.MobileNumber))
                ||
                string.Equals(account.InvoiceMedium, "Email") && account.Contacts.Any(c => c.IsBillingContact() && !string.IsNullOrWhiteSpace(c.EmailAddress))
                ||
                string.Equals(account.InvoiceMedium, "Paper")
            ).WithMessage("The Invoice Medium is not allowed. The three media allowed are Text (Needs MobileNumber), Email (Needs EmailAddress), or Paper.");

            RuleFor(a => a.Name).MaximumLength(100).NotEmpty();
            RuleFor(a => a.OrganisationalUnit).NotNull();
            RuleForEach(a => a.Contacts).SetValidator(contactValidator);
            RuleFor(a => a.Contacts)
                .Must(c => c != null && c.Count(cont => cont.IsBillingContact()) == 1)
                .WithMessage("Exactly 1 billing contact is required");
        }
    }
}