using System;
using System.Collections.Generic;
using System.Linq;
using AuthorizationServer.Infrastructure.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace AuthorizationServer.Infrastructure.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        private readonly IConfiguration Configuration;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        public UserConfiguration(IConfiguration configuration, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            Configuration = configuration;
            _passwordHasher = passwordHasher;
        }
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var defaultUsers = Configuration.GetSection("DefaultApplicationConfiguration")
                            .GetSection("User").Get<List<UserImport>>().Select(s => new ApplicationUser
                            {
                                PasswordHash = _passwordHasher.HashPassword(s, s.Password),
                                Email = s.Email,
                                FirstName = s.FirstName,
                                LastName = s.LastName,
                                UserName = s.UserName,
                                NormalizedEmail = s.NormalizedEmail,
                                NormalizedUserName = s.NormalizedUserName,
                                IsActive = s.IsActive,
                                SecurityStamp = Guid.NewGuid().ToString("D"),
                            });

            builder.ToTable("AspNetUsers");
            foreach (var user in defaultUsers)
            {
                builder.HasData(user);
            }

        }
    }

    public class UserImport : ApplicationUser
    {
        public string Password { get; set; }
    }
}