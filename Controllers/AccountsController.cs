using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Api.Controllers.ViewModels;
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

        public AccountsController(IAccountsService accountsService, IMapper mapper)
        {
            _accountsService = accountsService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [Route("{accountId}")]
        public AccountVm GetAccountById([FromRoute] int accountId)
        {
            var account = _accountsService.GetAccountById(accountId);
            var accountVm = _mapper.Map<AccountVm>(account);

            return accountVm;
        }

    }
}
