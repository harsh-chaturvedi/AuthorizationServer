using AuthorizationServer.Infrastructure.EntityConfiguration;
using AuthorizationServer.Infrastructure.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AuthorizationServer.Infrastructure.Database
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IConfiguration Configuration;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
                IConfiguration configuration, IPasswordHasher<ApplicationUser> passwordHasher) : base(options)
        {
            Configuration = configuration;
            _passwordHasher = passwordHasher;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration(Configuration, _passwordHasher));
            builder.ApplyConfiguration(new ClientConfiguration(Configuration));
            builder.ApplyConfiguration(new TenantConfiguration(Configuration));
            builder.ApplyConfiguration(new ClientTenantMapConfiguration(Configuration));
            builder.ApplyConfiguration(new ClientGrantTypesConfiguration(Configuration));
            builder.ApplyConfiguration(new AllowedScopesConfiguration(Configuration));
            builder.ApplyConfiguration(new ClientSecretsConfiguration(Configuration));
            builder.ApplyConfiguration(new RedirectUrisConfiguration(Configuration));
            builder.ApplyConfiguration(new PostRedirectUrisConfiguration(Configuration));
            builder.Entity<ClientTenantMap>(opts => opts.HasKey(x => new { x.ClientId, x.TenantId }));
            base.OnModelCreating(builder);
        }

        public DbSet<Tenant> Tenant { get; set; }

        public DbSet<ClientTenantMap> ClientTenantMap { get; set; }
    }
}