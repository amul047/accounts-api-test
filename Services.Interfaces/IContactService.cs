using Accounts.Api.Entities;

namespace Accounts.Api.Services.Interfaces
{
    public interface IContactService
    {
        Role GetRoleByName(string name);
    }
}