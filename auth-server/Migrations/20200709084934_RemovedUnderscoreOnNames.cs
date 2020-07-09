using Microsoft.EntityFrameworkCore.Migrations;

namespace auth_server.Migrations
{
    public partial class RemovedUnderscoreOnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_name",
                table: "UserTemplateAttribute");

            migrationBuilder.DropColumn(
                name: "_type",
                table: "UserTemplateAttribute");

            migrationBuilder.DropColumn(
                name: "_name",
                table: "State");

            migrationBuilder.DropColumn(
                name: "_email",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "_name",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "_password",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "_salt",
                table: "Organizations");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "UserTemplateAttribute",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "UserTemplateAttribute",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "State",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "salt",
                table: "Organizations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "UserTemplateAttribute");

            migrationBuilder.DropColumn(
                name: "type",
                table: "UserTemplateAttribute");

            migrationBuilder.DropColumn(
                name: "name",
                table: "State");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "salt",
                table: "Organizations");

            migrationBuilder.AddColumn<string>(
                name: "_name",
                table: "UserTemplateAttribute",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "_type",
                table: "UserTemplateAttribute",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "_name",
                table: "State",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_email",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_name",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_password",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_salt",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
