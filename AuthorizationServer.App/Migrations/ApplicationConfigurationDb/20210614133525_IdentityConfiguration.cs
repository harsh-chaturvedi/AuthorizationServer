using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthorizationServer.App.Migrations.ApplicationConfigurationDb
{
    public partial class IdentityConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "IdentityResources",
                columns: new[] { "Id", "Created", "Description", "DisplayName", "Emphasize", "Enabled", "Name", "NonEditable", "Required", "ShowInDiscoveryDocument", "Updated" },
                values: new object[] { 1, new DateTime(2021, 6, 14, 13, 35, 25, 292, DateTimeKind.Utc).AddTicks(3368), "OpenId", "OpenId", false, true, "openid", false, true, true, null });

            migrationBuilder.InsertData(
                table: "IdentityResources",
                columns: new[] { "Id", "Created", "Description", "DisplayName", "Emphasize", "Enabled", "Name", "NonEditable", "Required", "ShowInDiscoveryDocument", "Updated" },
                values: new object[] { 2, new DateTime(2021, 6, 14, 13, 35, 25, 294, DateTimeKind.Utc).AddTicks(6864), "Your user profile information (first name, last name, etc.)", "User profile", true, true, "profile", false, false, true, null });

            migrationBuilder.InsertData(
                table: "IdentityResourceClaims",
                columns: new[] { "Id", "IdentityResourceId", "Type" },
                values: new object[,]
                {
                    { 15, 1, "sub" },
                    { 1, 2, "updated_at" },
                    { 2, 2, "locale" },
                    { 3, 2, "zoneinfo" },
                    { 4, 2, "birthdate" },
                    { 5, 2, "website" },
                    { 6, 2, "picture" },
                    { 7, 2, "profile" },
                    { 8, 2, "preferred_username" },
                    { 9, 2, "nickname" },
                    { 10, 2, "middle_name" },
                    { 11, 2, "given_name" },
                    { 12, 2, "family_name" },
                    { 13, 2, "name" },
                    { 14, 2, "gender" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
