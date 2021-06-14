using System;
using AuthorizationServer.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthorizationServer.App.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    try
                    {
                        applicationDbContext.Database.Migrate();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                using (var applicationConfigurationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationConfigurationDbContext>())
                {
                    try
                    {
                        applicationConfigurationDbContext.Database.Migrate();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                return host;
            }
        }
    }
}