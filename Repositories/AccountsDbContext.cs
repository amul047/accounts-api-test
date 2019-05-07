using Accounts.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Api.Repositories
{
    public class AccountsDbContext : DbContext
    {
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        
        public DbSet<OrganisationalUnit> OrganisationalUnits { get; set; }
        
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>().ToTable("Accounts");
            builder.Entity<Account>().HasKey(a => a.AccountId);
            builder.Entity<Account>().HasOne(a => a.OrganisationalUnit).WithMany().HasForeignKey(a => a.OrganisationalUnitId).IsRequired();
            builder.Entity<Account>().HasMany(a => a.Contacts).WithOne(c => c.Account).HasForeignKey(c => c.AccountId).IsRequired();
            builder.Entity<Account>().Property(a => a.Name).HasMaxLength(100).IsRequired();

            builder.Entity<OrganisationalUnit>().ToTable("OrganisationalUnits");
            builder.Entity<OrganisationalUnit>().HasKey(ou => ou.OrganisationalUnitId);
            builder.Entity<OrganisationalUnit>().Property(ou => ou.Name).HasMaxLength(50).IsRequired();
            builder.Entity<OrganisationalUnit>().HasAlternateKey(ou => ou.Name);

            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().HasKey(r => r.RoleId);
            builder.Entity<Role>().Property(r => r.Name).HasMaxLength(50).IsRequired();
            builder.Entity<Role>().HasAlternateKey(r => r.Name);

            builder.Entity<Contact>().ToTable("Contacts");
            builder.Entity<Contact>().HasKey(c => c.ContactId);
            builder.Entity<Contact>().HasOne(c => c.Account).WithMany(a => a.Contacts).HasForeignKey(c => c.AccountId).IsRequired();
            builder.Entity<Contact>().Property(c => c.FirstName).HasMaxLength(200).IsRequired();
            builder.Entity<Contact>().Property(c => c.LastName).HasMaxLength(200).IsRequired();
            builder.Entity<Contact>().Property(c => c.PhoneNumber).HasMaxLength(15);
            builder.Entity<Contact>().Property(c => c.MobileNumber).HasMaxLength(15);
            builder.Entity<Contact>().Property(c => c.EmailAddress).HasMaxLength(250).IsRequired();
            builder.Entity<Contact>().HasOne(c => c.Role).WithMany().HasForeignKey(c => c.RoleId).IsRequired();
        }
    }
}