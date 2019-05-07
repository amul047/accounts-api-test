using System;

namespace Accounts.Api.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public string EmailAddress { get; set; }

        public int RoleId { get; set; }
        
        public Role Role { get; set; }

        public bool IsBillingContact()
        {
            return Role != null && string.Equals(Role.Name, "Billing", StringComparison.OrdinalIgnoreCase);
        }
    }
}