using Accounts.Api.Controllers.ViewModels;
using Accounts.Api.Entities;
using AutoMapper;

namespace Accounts.Api.Controllers
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<Account, AccountVm>()
                .ForMember(d => d.OrganisationalUnit, o => o.MapFrom(s => s.OrganisationalUnit.Name));
        }   
    }
}