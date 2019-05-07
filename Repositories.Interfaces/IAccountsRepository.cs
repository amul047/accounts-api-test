using System.Linq;
using Accounts.Api.Entities;

namespace Accounts.Api.Repositories.Interfaces
{
    public interface IAccountsRepository
    {
        IQueryable<Account> Accounts { get; }
        
        IQueryable<OrganisationalUnit> OrganisationalUnits { get; }

        IQueryable<Role> Roles { get; }

        void Create<TEntity>(TEntity entity) where TEntity : class;

        void Save<TEntity>(TEntity entity) where TEntity : class;
    }
}