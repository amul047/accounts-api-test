using Accounts.Api.Controllers.ViewModels;
using Accounts.Api.Entities;
using AutoMapper;

namespace Accounts.Api.Controllers
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<Contact, ContactVm>()
                .ForMember(d => d.Role, o => o.MapFrom(s => s.Role.Name));
        }
    }
}