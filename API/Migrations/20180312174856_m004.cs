using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace API.Migrations
{
    public partial class m004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppRoleServiceID",
                table: "AM_UserAppRoleServices",
                newName: "AppRoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppRoleID",
                table: "AM_UserAppRoleServices",
                newName: "AppRoleServiceID");
        }
    }
}
