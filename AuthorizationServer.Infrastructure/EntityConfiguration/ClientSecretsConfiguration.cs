using System.Collections.Generic;
using System.Linq;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace AuthorizationServer.Infrastructure.EntityConfiguration
{
    public class ClientSecretsConfiguration : IEntityTypeConfiguration<ClientSecret>
    {
        private readonly IConfiguration Configuration;
        public ClientSecretsConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(EntityTypeBuilder<ClientSecret> builder)
        {
            var defaultClients = Configuration.GetSection("DefaultApplicationConfiguration")
                                        .GetSection("Client").Get<List<Client>>().Select(x => x);

            builder.ToTable("ClientSecrets");
            foreach (var client in defaultClients)
            {
                foreach (var secret in client.ClientSecrets)
                {
                    secret.ClientId = client.Id;
                    builder.HasData(secret);
                }
            }
        }
    }
}