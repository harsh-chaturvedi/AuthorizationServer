using System.Collections.Generic;
using System.Linq;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace AuthorizationServer.Infrastructure.EntityConfiguration
{
    public class IdentityResourcesConfiguration : IEntityTypeConfiguration<IdentityResource>
    {
        private readonly IConfiguration Configuration;
        public IdentityResourcesConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(EntityTypeBuilder<IdentityResource> builder)
        {
            var identityResources = Configuration.GetSection("DefaultApplicationConfiguration")
                                        .GetSection("IdentityResources").Get<List<IdentityResource>>().Select(x => x);

            builder.ToTable("IdentityResources");
            foreach (var resource in identityResources)
            {
                builder.HasData(resource);
            }
        }
    }
}