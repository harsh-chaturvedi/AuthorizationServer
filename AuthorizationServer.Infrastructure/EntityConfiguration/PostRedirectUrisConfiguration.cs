using System.Collections.Generic;
using System.Linq;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace AuthorizationServer.Infrastructure.EntityConfiguration
{
    public class PostRedirectUrisConfiguration : IEntityTypeConfiguration<ClientPostLogoutRedirectUri>
    {
        private readonly IConfiguration Configuration;
        public PostRedirectUrisConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(EntityTypeBuilder<ClientPostLogoutRedirectUri> builder)
        {
            var defaultClients = Configuration.GetSection("DefaultApplicationConfiguration")
                                        .GetSection("Client").Get<List<Client>>().Select(x => x);

            builder.ToTable("ClientPostLogoutRedirectUris");
            foreach (var client in defaultClients)
            {
                foreach (var logoutRedirectUri in client.PostLogoutRedirectUris)
                {
                    logoutRedirectUri.ClientId = client.Id;
                    builder.HasData(logoutRedirectUri);
                }
            }
        }
    }
}