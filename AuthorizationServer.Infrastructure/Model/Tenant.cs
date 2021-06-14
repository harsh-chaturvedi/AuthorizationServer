namespace AuthorizationServer.Infrastructure.Model
{
    public class Tenant
    {
        public int Id { get; set; }

        public string TenantDomain { get; set; }

        public string TenantUri { get; set; }

        public string TenantName { get; set; }

        public bool IsActive { get; set; }
    }
}