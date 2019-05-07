using System.Linq;
using Accounts.Api.Entities;

namespace Accounts.Api.Repositories.Interfaces
{
    public interface IAccountsRepository
    {
        IQueryable<Account> Accounts { get; }

        void Create<TEntity>(TEntity entity) where TEntity : class;
    }
}