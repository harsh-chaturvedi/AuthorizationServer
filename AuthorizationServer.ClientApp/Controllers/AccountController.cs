using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AuthorizationServer.ClientApp.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private readonly IConfiguration Configuration;

        public IActionResult Logout()
        {
            var authServerUrl = new Uri(Configuration["Authority"]);
            var applicationUri = new Uri(Configuration["ApplicationUri"]);
            // HttpContext
            ResetCookies();
            var logoutUrl = new Uri(authServerUrl, string.Format("account/logout?ReturnUri={0}", applicationUri));
            return Redirect(logoutUrl.ToString());
        }

        private void ResetCookies()
        {
            HttpContext.Response.Cookies.Delete(".AspNetCore.cookies");
            HttpContext.Response.Cookies.Delete(".AspNetCore.cookiesC1");
            HttpContext.Response.Cookies.Delete(".AspNetCore.cookiesC2");
            HttpContext.Response.Cookies.Delete(".AspNetCore.Identity.Application");
            HttpContext.Response.Cookies.Delete("idsrv.session");
        }
    }
}