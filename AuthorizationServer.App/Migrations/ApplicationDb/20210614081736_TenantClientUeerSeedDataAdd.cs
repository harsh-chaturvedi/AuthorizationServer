using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthorizationServer.App.Migrations.ApplicationDb
{
    public partial class TenantClientUeerSeedDataAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantDomain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientTenantMaps",
                columns: table => new
                {
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTenantMaps", x => new { x.ClientId, x.TenantId });
                    table.ForeignKey(
                        name: "FK_ClientTenantMaps_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientTenantMaps_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OrganizationId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TenantId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "47cdab8a-048e-4848-8a93-a5f35d4d4327", 0, "fe269bd1-7121-4a66-93be-400119a5f0b3", "ApplicationUser", "Admin@application.com", false, "AISAdmin", true, "SuperAdmin", false, null, "ADMIN@APPLICATION.COM", "ADMIN@APPLICATION.COM", null, "4jcbo8wYXZYH0UWVrXrkrHUbQndxILcXqRWkHhwDEDrQJvCK2xuwrW9CXuNKkeowV7U8cV8486jIsmBbBlg+Fw==", null, false, "1f379cf9-d182-4bb4-a07a-e7a75d549ecd", null, false, "Admin@application.com" },
                    { "4b62bbb5-d807-4bfb-8e6c-4bb001c36a15", 0, "9bf51d52-e405-4443-8985-66fb2db8d224", "ApplicationUser", "Admin1@application.com", false, "AISAdmin1", true, "SuperAdmin", false, null, "ADMIN1@APPLICATION.COM", "ADMIN1@APPLICATION.COM", null, "NtCW8kkn7Rz1EY3MXo7V7qYq2vv602NNT/BjrpnZfq2z+oQAzRYjDjWlJ5W1+9HlhtkLphfEBWSRNRk44Y0W0w==", null, false, "2fa1d650-56f9-4d4a-a15b-8fdf46edec26", null, false, "Admin1@application.com" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AbsoluteRefreshTokenLifetime", "AccessTokenLifetime", "AccessTokenType", "AllowAccessTokensViaBrowser", "AllowOfflineAccess", "AllowPlainTextPkce", "AllowRememberConsent", "AllowedIdentityTokenSigningAlgorithms", "AlwaysIncludeUserClaimsInIdToken", "AlwaysSendClientClaims", "AuthorizationCodeLifetime", "BackChannelLogoutSessionRequired", "BackChannelLogoutUri", "ClientClaimsPrefix", "ClientId", "ClientName", "ClientUri", "ConsentLifetime", "Created", "Description", "DeviceCodeLifetime", "EnableLocalLogin", "Enabled", "FrontChannelLogoutSessionRequired", "FrontChannelLogoutUri", "IdentityTokenLifetime", "IncludeJwtId", "LastAccessed", "LogoUri", "NonEditable", "PairWiseSubjectSalt", "ProtocolType", "RefreshTokenExpiration", "RefreshTokenUsage", "RequireClientSecret", "RequireConsent", "RequirePkce", "RequireRequestObject", "SlidingRefreshTokenLifetime", "UpdateAccessTokenClaimsOnRefresh", "Updated", "UserCodeType", "UserSsoLifetime" },
                values: new object[] { 1, 2592000, 1209600, 0, false, true, false, false, null, true, true, 600, true, "", "client_", "local", "Local Client", "https://localhost:7001/", null, new DateTime(2021, 6, 14, 8, 17, 36, 62, DateTimeKind.Utc).AddTicks(2547), "Client for localhost:7001", 300, true, true, true, "", 1209600, false, null, "", false, "", "oidc", 0, 1, false, false, false, false, 1209600, true, null, null, null });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "IsActive", "TenantDomain", "TenantName", "TenantUri" },
                values: new object[] { 1, true, "localhost:7001", "localhost:", "https://localhost:7001/" });

            migrationBuilder.InsertData(
                table: "ClientGrantTypes",
                columns: new[] { "Id", "ClientId", "GrantType" },
                values: new object[] { 1, 1, "authorization_code" });

            migrationBuilder.InsertData(
                table: "ClientPostLogoutRedirectUris",
                columns: new[] { "Id", "ClientId", "PostLogoutRedirectUri" },
                values: new object[] { 1, 1, "https://localhost:7001/" });

            migrationBuilder.InsertData(
                table: "ClientRedirectUris",
                columns: new[] { "Id", "ClientId", "RedirectUri" },
                values: new object[] { 1, 1, "https://localhost:7001/signin-oidc" });

            migrationBuilder.InsertData(
                table: "ClientScopes",
                columns: new[] { "Id", "ClientId", "Scope" },
                values: new object[,]
                {
                    { 1, 1, "openid" },
                    { 2, 1, "profile" }
                });

            migrationBuilder.InsertData(
                table: "ClientSecrets",
                columns: new[] { "Id", "ClientId", "Created", "Description", "Expiration", "Type", "Value" },
                values: new object[] { 1, 1, new DateTime(2021, 6, 14, 8, 17, 36, 84, DateTimeKind.Utc).AddTicks(3185), "Client secret", new DateTime(2026, 2, 10, 13, 46, 6, 283, DateTimeKind.Local).AddTicks(1187), "SharedSecret", "secret" });

            migrationBuilder.InsertData(
                table: "ClientTenantMaps",
                columns: new[] { "ClientId", "TenantId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ClientTenantMaps_TenantId",
                table: "ClientTenantMaps",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientTenantMaps");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47cdab8a-048e-4848-8a93-a5f35d4d4327");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b62bbb5-d807-4bfb-8e6c-4bb001c36a15");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AspNetUsers");
        }
    }
}
