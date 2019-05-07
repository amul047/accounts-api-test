using Accounts.Api.Entities;

namespace Accounts.Api.Services.Interfaces
{
    public interface IAccountsService
    {
        Account GetAccountById(int accountId);

        void CreateAccount(Account account);

        void SaveInvoiceMediumForAccount(int accountId, string invoiceMedium);

        OrganisationalUnit GetOrganisationalUnitByName(string name);
    }
}