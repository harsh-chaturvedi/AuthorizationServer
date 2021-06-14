using System.Collections.Generic;
using System.Linq;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace AuthorizationServer.Infrastructure.EntityConfiguration
{
    public class ClientGrantTypesConfiguration : IEntityTypeConfiguration<ClientGrantType>
    {
        private readonly IConfiguration Configuration;
        public ClientGrantTypesConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(EntityTypeBuilder<ClientGrantType> builder)
        {
            var defaultClients = Configuration.GetSection("DefaultApplicationConfiguration")
                                        .GetSection("Client").Get<List<Client>>().Select(x => x);

            builder.ToTable("ClientGrantTypes");
            foreach (var client in defaultClients)
            {
                foreach (var grantType in client.AllowedGrantTypes)
                {
                    grantType.ClientId = client.Id;
                    builder.HasData(grantType);
                }
            }
        }
    }
}