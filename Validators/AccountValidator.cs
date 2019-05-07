using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Accounts.Api.Entities;
using FluentValidation;
using System.Linq;

namespace Accounts.Api.Validators
{
    public class AccountValidator : AbstractValidator<Account>
    {
        private static readonly List<string> ValidInvoiceMedia = new List<string> {"Text", "Email", "Paper"};

        public AccountValidator(IValidator<Contact> contactValidator)
        {
            RuleFor(a => a.InvoiceMedium).Must(x => ValidInvoiceMedia.Contains(x))
                .WithMessage("Invoice can only be recieved in of these media: " + string.Join(",", ValidInvoiceMedia));
            RuleFor(a => a.Name).MaximumLength(100).NotEmpty();
            RuleFor(a => a.OrganisationalUnit).NotNull();
            RuleForEach(a => a.Contacts).SetValidator(contactValidator);
            RuleFor(a => a.Contacts)
                .Must(c => c != null && c.Count(cont => cont.IsBillingContact()) == 1)
                .WithMessage("Exactly 1 billing contact is required");
        }
    }
}