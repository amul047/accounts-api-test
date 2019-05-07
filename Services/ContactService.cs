using System.Linq;
using Accounts.Api.Entities;
using Accounts.Api.Repositories.Interfaces;
using Accounts.Api.Services.Interfaces;

namespace Accounts.Api.Services
{
    public class ContactService : IContactService
    {
        private readonly IAccountsRepository _accountsRepository;

        public ContactService(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }
        
        public Role GetRoleByName(string name)
        {
            return _accountsRepository.Roles.SingleOrDefault(r => r.Name == name);
        }
    }
}