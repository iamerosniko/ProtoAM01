using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace API.Migrations
{
    public partial class m003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppRoleID",
                table: "AM_AppRoleServices",
                newName: "AppRoleServiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppRoleServiceID",
                table: "AM_AppRoleServices",
                newName: "AppRoleID");
        }
    }
}
