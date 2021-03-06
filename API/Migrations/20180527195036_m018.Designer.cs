﻿// <auto-generated />
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace API.Migrations
{
    [DbContext(typeof(AMContext))]
    [Migration("20180527195036_m018")]
    partial class m018
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Entities.AM_Application", b =>
                {
                    b.Property<int>("AppID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppMemberName");

                    b.Property<string>("AppName");

                    b.Property<string>("AppSecurityKey");

                    b.Property<string>("AppUrl");

                    b.HasKey("AppID");

                    b.ToTable("AM_Applications");
                });

            modelBuilder.Entity("API.Entities.AM_AppRoleService", b =>
                {
                    b.Property<int>("AppRoleServiceID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppID");

                    b.Property<int>("RoleID");

                    b.HasKey("AppRoleServiceID");

                    b.ToTable("AM_AppRoleServices");
                });

            modelBuilder.Entity("API.Entities.AM_InheritedRole", b =>
                {
                    b.Property<int>("InheritedRolesID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MainRoleID");

                    b.Property<int>("RoleID");

                    b.HasKey("InheritedRolesID");

                    b.ToTable("AM_InheritedRoles");
                });

            modelBuilder.Entity("API.Entities.AM_Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName");

                    b.HasKey("RoleID");

                    b.ToTable("AM_Roles");
                });

            modelBuilder.Entity("API.Entities.AM_RoleServices", b =>
                {
                    b.Property<int>("RoleServiceID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoleID");

                    b.Property<string>("ServiceDesc");

                    b.Property<string>("ServiceName");

                    b.HasKey("RoleServiceID");

                    b.ToTable("AM_RoleServices");
                });

            modelBuilder.Entity("API.Entities.AM_ServiceAttribute", b =>
                {
                    b.Property<int>("ServiceAttributeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AttribDesc");

                    b.Property<string>("AttribName");

                    b.Property<int>("RoleServiceID");

                    b.HasKey("ServiceAttributeID");

                    b.ToTable("AM_ServiceAttributes");
                });

            modelBuilder.Entity("API.Entities.AM_User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("UserName");

                    b.HasKey("UserID");

                    b.ToTable("AM_Users");
                });

            modelBuilder.Entity("API.Entities.AM_UserApp", b =>
                {
                    b.Property<int>("UserAppID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppID");

                    b.Property<int>("UserID");

                    b.HasKey("UserAppID");

                    b.ToTable("AM_UserApps");
                });

            modelBuilder.Entity("API.Entities.AM_UserAppRoleService", b =>
                {
                    b.Property<int>("UserAppRoleServiceID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoleID");

                    b.Property<int>("UserAppID");

                    b.HasKey("UserAppRoleServiceID");

                    b.ToTable("AM_UserAppRoleServices");
                });
#pragma warning restore 612, 618
        }
    }
}
