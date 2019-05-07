using System.Collections.Generic;

namespace Accounts.Api.Entities
{
    public class Account
    {
        public int AccountId { get; set; }

        public string Name { get; set; }

        public IList<Contact> Contacts { get; set; }

        public int OrganisationalUnitId { get; set; }

        public OrganisationalUnit OrganisationalUnit { get; set; }
        
    }
}