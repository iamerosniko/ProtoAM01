using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace API.Migrations
{
    public partial class m016 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AM_Attributes");

            migrationBuilder.DropColumn(
                name: "AttribID",
                table: "AM_ServiceAttributes");

            migrationBuilder.AddColumn<string>(
                name: "AttribDesc",
                table: "AM_ServiceAttributes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttribName",
                table: "AM_ServiceAttributes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttribDesc",
                table: "AM_ServiceAttributes");

            migrationBuilder.DropColumn(
                name: "AttribName",
                table: "AM_ServiceAttributes");

            migrationBuilder.AddColumn<int>(
                name: "AttribID",
                table: "AM_ServiceAttributes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AM_Attributes",
                columns: table => new
                {
                    AttribID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttribDesc = table.Column<string>(nullable: true),
                    AttribName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_Attributes", x => x.AttribID);
                });
        }
    }
}
