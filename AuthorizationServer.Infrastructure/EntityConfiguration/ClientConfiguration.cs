using System;
using System.Collections.Generic;
using System.Linq;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace AuthorizationServer.Infrastructure.EntityConfiguration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        private readonly IConfiguration Configuration;
        public ClientConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            var defaultClients = Configuration.GetSection("DefaultApplicationConfiguration")
                            .GetSection("Client").Get<List<Client>>().Select(x => x);

            builder.ToTable("Clients");
            foreach (var client in defaultClients)
            {
                client.AllowedGrantTypes = null;
                client.AllowedScopes = null;
                client.ClientSecrets = null;
                client.RedirectUris = null;
                client.PostLogoutRedirectUris = null;
                builder.HasData(client);
            }
        }
    }
}