using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace auth_server.Migrations
{
    public partial class EmailAsKeyOrgs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTemplates_Organizations_organization_oid",
                table: "UserTemplates");

            migrationBuilder.DropIndex(
                name: "IX_UserTemplates_organization_oid",
                table: "UserTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "organization_oid",
                table: "UserTemplates");

            migrationBuilder.DropColumn(
                name: "_oid",
                table: "Organizations");

            migrationBuilder.AddColumn<string>(
                name: "organizationemail",
                table: "UserTemplates",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Organizations",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "IX_UserTemplates_organizationemail",
                table: "UserTemplates",
                column: "organizationemail");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTemplates_Organizations_organizationemail",
                table: "UserTemplates",
                column: "organizationemail",
                principalTable: "Organizations",
                principalColumn: "email",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTemplates_Organizations_organizationemail",
                table: "UserTemplates");

            migrationBuilder.DropIndex(
                name: "IX_UserTemplates_organizationemail",
                table: "UserTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "organizationemail",
                table: "UserTemplates");

            migrationBuilder.AddColumn<Guid>(
                name: "organization_oid",
                table: "UserTemplates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "_oid",
                table: "Organizations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "_oid");

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
    }
}
