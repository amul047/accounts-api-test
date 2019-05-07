using System.Collections.Generic;
using Accounts.Api.Controllers.ViewModels;
using Accounts.Api.Entities;
using Accounts.Api.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountsService;
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;

        public AccountsController(IAccountsService accountsService, IMapper mapper, IContactService contactService)
        {
            _accountsService = accountsService;
            _mapper = mapper;
            _contactService = contactService;
        }
        
        [HttpGet]
        [Route("{accountId}")]
        public AccountVm GetAccountById([FromRoute] int accountId)
        {
            var account = _accountsService.GetAccountById(accountId);
            var accountVm = _mapper.Map<AccountVm>(account);

            return accountVm;
        }


        [HttpPost]
        public AccountCreatedVm CreateAccount([FromBody] AccountEditVm accountEditVm)
        {
            var account = MapAccount(accountEditVm);
            _accountsService.CreateAccount(account);
            
            return new AccountCreatedVm { AccountId = account.AccountId };
        }


        private Account MapAccount(AccountEditVm accountEditVm)
        {
            var account = new Account
            {
                Name = accountEditVm?.Name,
                OrganisationalUnit = _accountsService.GetOrganisationalUnitByName(accountEditVm?.OrganisationalUnit),
                Contacts = new List<Contact>(),
            };

            if (accountEditVm?.Contacts != null)
            {
                foreach (var c in accountEditVm.Contacts)
                {
                    var contact = new Contact
                    {
                        Account = account,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        PhoneNumber = c.PhoneNumber,
                        MobileNumber = c.MobileNumber,
                        EmailAddress = c.EmailAddress,
                        Role = _contactService.GetRoleByName(c.Role),
                    };
                    account.Contacts.Add(contact);
                }
            }

            return account;
        }

    }
}
