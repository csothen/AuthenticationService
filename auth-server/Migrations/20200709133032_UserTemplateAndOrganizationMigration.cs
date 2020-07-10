using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace auth_server.Migrations
{
    public partial class UserTemplateAndOrganizationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_UserTemplates__templateId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations__templateId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "_templateId",
                table: "Organizations");

            migrationBuilder.AddColumn<Guid>(
                name: "organization_oid",
                table: "UserTemplates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTemplates_organization_oid",
                table: "UserTemplates",
                column: "organization_oid");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTemplates_Organizations_organization_oid",
                table: "UserTemplates",
                column: "organization_oid",
                principalTable: "Organizations",
                principalColumn: "_oid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTemplates_Organizations_organization_oid",
                table: "UserTemplates");

            migrationBuilder.DropIndex(
                name: "IX_UserTemplates_organization_oid",
                table: "UserTemplates");

            migrationBuilder.DropColumn(
                name: "organization_oid",
                table: "UserTemplates");

            migrationBuilder.AddColumn<Guid>(
                name: "_templateId",
                table: "Organizations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations__templateId",
                table: "Organizations",
                column: "_templateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_UserTemplates__templateId",
                table: "Organizations",
                column: "_templateId",
                principalTable: "UserTemplates",
                principalColumn: "_tid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
