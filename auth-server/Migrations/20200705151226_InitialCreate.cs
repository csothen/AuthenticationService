using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace auth_server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    _cid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x._cid);
                });

            migrationBuilder.CreateTable(
                name: "UserTemplates",
                columns: table => new
                {
                    _tid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTemplates", x => x._tid);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    _oid = table.Column<Guid>(nullable: false),
                    _templateId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x._oid);
                    table.ForeignKey(
                        name: "FK_Organizations_UserTemplates__templateId",
                        column: x => x._templateId,
                        principalTable: "UserTemplates",
                        principalColumn: "_tid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organizations__templateId",
                table: "Organizations",
                column: "_templateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "UserTemplates");
        }
    }
}
