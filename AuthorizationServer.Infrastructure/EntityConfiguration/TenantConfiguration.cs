using System.Collections.Generic;
using System.Linq;
using AuthorizationServer.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace AuthorizationServer.Infrastructure.EntityConfiguration
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        private readonly IConfiguration Configuration;
        public TenantConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            var defaultTenants = Configuration.GetSection("DefaultApplicationConfiguration")
                            .GetSection("Tenant").Get<List<Tenant>>().Select(x => x);

            builder.ToTable("Tenants");
            foreach (var item in defaultTenants)
            {
                builder.HasData(item);
            }
        }
    }
}