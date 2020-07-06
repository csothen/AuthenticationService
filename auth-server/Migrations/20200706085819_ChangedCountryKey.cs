using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace auth_server.Migrations
{
    public partial class ChangedCountryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_State_Countries_Country_cid",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Country_cid",
                table: "State");

            migrationBuilder.DropColumn(
                name: "_cid",
                table: "Countries");

            migrationBuilder.AddColumn<string>(
                name: "Country_name",
                table: "State",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_name",
                table: "State",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "_name",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                columns: new[] { "Country_name", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "_name");

            migrationBuilder.AddForeignKey(
                name: "FK_State_Countries_Country_name",
                table: "State",
                column: "Country_name",
                principalTable: "Countries",
                principalColumn: "_name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_State_Countries_Country_name",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Country_name",
                table: "State");

            migrationBuilder.DropColumn(
                name: "_name",
                table: "State");

            migrationBuilder.AddColumn<Guid>(
                name: "Country_cid",
                table: "State",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "_name",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "_cid",
                table: "Countries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                columns: new[] { "Country_cid", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "_cid");

            migrationBuilder.AddForeignKey(
                name: "FK_State_Countries_Country_cid",
                table: "State",
                column: "Country_cid",
                principalTable: "Countries",
                principalColumn: "_cid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
