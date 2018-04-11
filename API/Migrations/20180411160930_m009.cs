using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace API.Migrations
{
    public partial class m009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AM_Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AM_Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AM_Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AM_Users");
        }
    }
}
