using System.Collections.Generic;
using System.Linq;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace AuthorizationServer.Infrastructure.EntityConfiguration
{
    public class IdentityResourceClaimsConfiguration : IEntityTypeConfiguration<IdentityResourceClaim>
    {
        private readonly IConfiguration Configuration;
        public IdentityResourceClaimsConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(EntityTypeBuilder<IdentityResourceClaim> builder)
        {
            var identityResourceClaims = Configuration.GetSection("DefaultApplicationConfiguration")
                                        .GetSection("IdentityResourceClaims").Get<List<IdentityResourceClaim>>().Select(x => x);

            builder.ToTable("IdentityResourceClaims");
            foreach (var resourceClaims in identityResourceClaims)
            {
                builder.HasData(resourceClaims);
            }
        }
    }
}