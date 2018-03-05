﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AM_Applications",
                columns: table => new
                {
                    AppID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppMemberName = table.Column<string>(nullable: true),
                    AppName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_Applications", x => x.AppID);
                });

            migrationBuilder.CreateTable(
                name: "AM_AppRoles",
                columns: table => new
                {
                    AppRoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppID = table.Column<int>(nullable: false),
                    AttribID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    ServiceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_AppRoles", x => x.AppRoleID);
                });

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

            migrationBuilder.CreateTable(
                name: "AM_Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "AM_Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppID = table.Column<int>(nullable: false),
                    ServiceDesc = table.Column<string>(nullable: true),
                    ServiceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_Services", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "AM_UserApps",
                columns: table => new
                {
                    UserAppID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_UserApps", x => x.UserAppID);
                });

            migrationBuilder.CreateTable(
                name: "AM_UserAppServices",
                columns: table => new
                {
                    UserAppServicesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleID = table.Column<int>(nullable: false),
                    ServiceID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_UserAppServices", x => x.UserAppServicesID);
                });

            migrationBuilder.CreateTable(
                name: "AM_Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_Users", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AM_Applications");

            migrationBuilder.DropTable(
                name: "AM_AppRoles");

            migrationBuilder.DropTable(
                name: "AM_Attributes");

            migrationBuilder.DropTable(
                name: "AM_Roles");

            migrationBuilder.DropTable(
                name: "AM_Services");

            migrationBuilder.DropTable(
                name: "AM_UserApps");

            migrationBuilder.DropTable(
                name: "AM_UserAppServices");

            migrationBuilder.DropTable(
                name: "AM_Users");
        }
    }
}
