using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace API.Migrations
{
    public partial class m017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AM_Services");

            migrationBuilder.DropColumn(
                name: "ServiceID",
                table: "AM_RoleServices");

            migrationBuilder.AddColumn<string>(
                name: "ServiceDesc",
                table: "AM_RoleServices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "AM_RoleServices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceDesc",
                table: "AM_RoleServices");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "AM_RoleServices");

            migrationBuilder.AddColumn<int>(
                name: "ServiceID",
                table: "AM_RoleServices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AM_Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceDesc = table.Column<string>(nullable: true),
                    ServiceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_Services", x => x.ServiceID);
                });
        }
    }
}
