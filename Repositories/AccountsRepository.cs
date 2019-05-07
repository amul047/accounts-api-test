using System.Linq;
using Accounts.Api.Entities;
using Accounts.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Api.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly AccountsDbContext _db;

        public AccountsRepository(AccountsDbContext db)
        {
            _db = db;
        }

        public IQueryable<Account> Accounts => _db.Accounts
            .Include(a => a.OrganisationalUnit)
            .Include(a => a.Contacts)
                .ThenInclude(c => c.Role);

        public IQueryable<OrganisationalUnit> OrganisationalUnits => _db.OrganisationalUnits;

        public IQueryable<Role> Roles => _db.Roles;

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            _db.Add(entity);
            _db.SaveChanges();
        }

        public void Save<TEntity>(TEntity entity) where TEntity : class
        {
            _db.SaveChanges();
        }
    }
}