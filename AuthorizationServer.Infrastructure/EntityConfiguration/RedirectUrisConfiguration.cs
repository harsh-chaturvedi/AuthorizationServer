using System.Collections.Generic;
using System.Linq;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace AuthorizationServer.Infrastructure.EntityConfiguration
{
    public class RedirectUrisConfiguration : IEntityTypeConfiguration<ClientRedirectUri>
    {
        private readonly IConfiguration Configuration;
        public RedirectUrisConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(EntityTypeBuilder<ClientRedirectUri> builder)
        {
            var defaultClients = Configuration.GetSection("DefaultApplicationConfiguration")
                                        .GetSection("Client").Get<List<Client>>().Select(x => x);

            builder.ToTable("ClientRedirectUris");
            foreach (var client in defaultClients)
            {
                foreach (var redirectUris in client.RedirectUris)
                {
                    redirectUris.ClientId = client.Id;
                    builder.HasData(redirectUris);
                }
            }
        }
    }
}