using AuthorizationServer.Infrastructure.EntityConfiguration;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AuthorizationServer.Infrastructure.Database
{
    public class ApplicationConfigurationDbContext : ConfigurationDbContext
    {
        private readonly IConfiguration Configuration;
        public ApplicationConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options,
            ConfigurationStoreOptions storeOptions, IConfiguration configuration)
            : base(options, storeOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new IdentityResourcesConfiguration(Configuration));
            builder.ApplyConfiguration(new IdentityResourceClaimsConfiguration(Configuration));
            base.OnModelCreating(builder);
        }
    }
}