using System;
using System.Security.Cryptography;
using System.Text;
using AuthorizationServer.Infrastructure.Model;
using Microsoft.AspNetCore.Identity;

namespace AuthorizationServer.Infrastructure.Services
{
    public class ApplicationPasswordHasher : IPasswordHasher<ApplicationUser>
    {
        public string HashPassword(ApplicationUser user, string password)
        {
            return GetPasswordHash(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(ApplicationUser user, string hashedPassword, string providedPassword)
        {
            return GetPasswordHash(providedPassword) == hashedPassword ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }

        private string GetPasswordHash(string password)
        {
            var SHA256 = new SHA512CryptoServiceProvider();

            using (var SHA512 = new SHA512Managed())
            {
                byte[] encData = SHA512.ComputeHash(Encoding.ASCII.GetBytes(password));
                return Convert.ToBase64String(encData);
            }
        }
    }
}