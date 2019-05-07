using System.Linq;
using Accounts.Api.Entities;
using Accounts.Api.Repositories.Interfaces;
using Accounts.Api.Services.Interfaces;
using FluentValidation;

namespace Accounts.Api.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository _accountsRepository;
        private readonly IValidator<Account> _accountValidator;

        public AccountsService(IAccountsRepository accountsRepository, IValidator<Account> accountValidator)
        {
            _accountsRepository = accountsRepository;
            _accountValidator = accountValidator;
        }
        
        public Account GetAccountById(int accountId)
        {
            return _accountsRepository.Accounts.SingleOrDefault(a => a.AccountId == accountId);
        }

        public void CreateAccount(Account account)
        {
            _accountValidator.ValidateAndThrow(account);
    
            _accountsRepository.Create(account);
        }

        public void SaveInvoiceMediumForAccount(int accountId, string invoiceMedium)
        {
            var account = _accountsRepository.Accounts.SingleOrDefault(a => a.AccountId == accountId);

            if (account == null)
            {
                throw new ValidationException("Account Id is invalid");
            }

            account.InvoiceMedium = invoiceMedium;
            _accountsRepository.Save(account);
        }

        public void SaveAccount(Account account)
        {
            _accountsRepository.Save(account);
        }

        public OrganisationalUnit GetOrganisationalUnitByName(string name)
        {
            return _accountsRepository.OrganisationalUnits.SingleOrDefault(ou => ou.Name == name);
        }
    }
}