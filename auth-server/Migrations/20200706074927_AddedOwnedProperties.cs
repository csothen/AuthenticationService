using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace auth_server.Migrations
{
    public partial class AddedOwnedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "_email",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_name",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_password",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_salt",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_name",
                table: "Countries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Country_cid = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => new { x.Country_cid, x.Id });
                    table.ForeignKey(
                        name: "FK_State_Countries_Country_cid",
                        column: x => x.Country_cid,
                        principalTable: "Countries",
                        principalColumn: "_cid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTemplateAttribute",
                columns: table => new
                {
                    UserTemplate_tid = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _name = table.Column<string>(nullable: true),
                    _type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTemplateAttribute", x => new { x.UserTemplate_tid, x.Id });
                    table.ForeignKey(
                        name: "FK_UserTemplateAttribute_UserTemplates_UserTemplate_tid",
                        column: x => x.UserTemplate_tid,
                        principalTable: "UserTemplates",
                        principalColumn: "_tid",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "UserTemplateAttribute");

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

            migrationBuilder.DropColumn(
                name: "_name",
                table: "Countries");
        }
    }
}
