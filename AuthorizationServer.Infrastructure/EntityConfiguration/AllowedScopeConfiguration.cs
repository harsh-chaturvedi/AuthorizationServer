using System.Collections.Generic;
using System.Linq;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace AuthorizationServer.Infrastructure.EntityConfiguration
{
    public class AllowedScopesConfiguration : IEntityTypeConfiguration<ClientScope>
    {
        private readonly IConfiguration Configuration;
        public AllowedScopesConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(EntityTypeBuilder<ClientScope> builder)
        {
            var defaultClients = Configuration.GetSection("DefaultApplicationConfiguration")
                                        .GetSection("Client").Get<List<Client>>().Select(x => x);

            builder.ToTable("ClientScopes");
            foreach (var client in defaultClients)
            {
                foreach (var scope in client.AllowedScopes)
                {
                    scope.ClientId = client.Id;
                    builder.HasData(scope);
                }
            }
        }
    }
}