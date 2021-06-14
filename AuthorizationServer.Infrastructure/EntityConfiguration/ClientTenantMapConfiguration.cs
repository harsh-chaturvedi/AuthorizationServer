using System.Collections.Generic;
using System.Linq;
using AuthorizationServer.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace AuthorizationServer.Infrastructure.EntityConfiguration
{
    public class ClientTenantMapConfiguration : IEntityTypeConfiguration<ClientTenantMap>
    {
        private readonly IConfiguration Configuration;
        public ClientTenantMapConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(EntityTypeBuilder<ClientTenantMap> builder)
        {
            var clientTenantMap = Configuration.GetSection("DefaultApplicationConfiguration")
                            .GetSection("ClientTenantMap").Get<List<ClientTenantMap>>().Select(x => x);

            builder.ToTable("ClientTenantMaps");
            foreach (var item in clientTenantMap)
            {
                builder.HasData(item);
            }
        }
    }
}