using AuthorizationServer.Infrastructure.Database;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationServer.App.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ConfigurationDbContext _configurationDbContext;
        public ClientController(ApplicationDbContext dbContext, ConfigurationDbContext configurationDbContext)
        {
            _dbContext = dbContext;
            _configurationDbContext = configurationDbContext;
        }

        public IActionResult Get()
        {
            var result =
            (_configurationDbContext.Clients
                .Include(x => x.RedirectUris)
                .Include(x => x.AllowedGrantTypes)
                .Include(x => x.AllowedScopes)
                .Include(x => x.PostLogoutRedirectUris));

            return Ok(result);
        }
    }
}