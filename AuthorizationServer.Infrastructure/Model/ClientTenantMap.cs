using System.ComponentModel.DataAnnotations.Schema;
using IdentityServer4.EntityFramework.Entities;

namespace AuthorizationServer.Infrastructure.Model
{
    public class ClientTenantMap
    {
        public int TenantId { get; set; }
        [ForeignKey("TenantId")]
        public virtual Tenant Tenant { get; set; }

        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
    }
}