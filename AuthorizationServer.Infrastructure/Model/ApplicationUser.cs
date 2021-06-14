using System;
using Microsoft.AspNetCore.Identity;

namespace AuthorizationServer.Infrastructure.Model
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {

        }
        public ApplicationUser(string userName) : base(userName)
        {

        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public int? TenantId { get; set; }

        public Guid? OrganizationId { get; set; }
    }
}