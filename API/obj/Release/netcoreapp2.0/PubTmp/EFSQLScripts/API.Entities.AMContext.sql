IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180309131313_init')
BEGIN
    CREATE TABLE [AM_Applications] (
        [AppID] int NOT NULL IDENTITY,
        [AppMemberName] nvarchar(max) NULL,
        [AppName] nvarchar(max) NULL,
        [Status] int NOT NULL,
        CONSTRAINT [PK_AM_Applications] PRIMARY KEY ([AppID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180309131313_init')
BEGIN
    CREATE TABLE [AM_AppRoleServices] (
        [AppRoleID] int NOT NULL IDENTITY,
        [AppID] int NOT NULL,
        [RoleID] int NOT NULL,
        [ServiceID] int NOT NULL,
        CONSTRAINT [PK_AM_AppRoleServices] PRIMARY KEY ([AppRoleID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180309131313_init')
BEGIN
    CREATE TABLE [AM_Attributes] (
        [AttribID] int NOT NULL IDENTITY,
        [AttribDesc] nvarchar(max) NULL,
        [AttribName] nvarchar(max) NULL,
        CONSTRAINT [PK_AM_Attributes] PRIMARY KEY ([AttribID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180309131313_init')
BEGIN
    CREATE TABLE [AM_Roles] (
        [RoleID] int NOT NULL IDENTITY,
        [RoleName] nvarchar(max) NULL,
        CONSTRAINT [PK_AM_Roles] PRIMARY KEY ([RoleID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180309131313_init')
BEGIN
    CREATE TABLE [AM_ServiceAttributes] (
        [ServiceAttributeID] int NOT NULL IDENTITY,
        [AttribID] int NOT NULL,
        [ServiceID] int NOT NULL,
        CONSTRAINT [PK_AM_ServiceAttributes] PRIMARY KEY ([ServiceAttributeID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180309131313_init')
BEGIN
    CREATE TABLE [AM_Services] (
        [ServiceID] int NOT NULL IDENTITY,
        [AppID] int NOT NULL,
        [ServiceDesc] nvarchar(max) NULL,
        [ServiceName] nvarchar(max) NULL,
        CONSTRAINT [PK_AM_Services] PRIMARY KEY ([ServiceID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180309131313_init')
BEGIN
    CREATE TABLE [AM_UserAppRoleServices] (
        [UserAppRoleServiceID] int NOT NULL IDENTITY,
        [AppRoleServiceID] int NOT NULL,
        [UserAppID] int NOT NULL,
        CONSTRAINT [PK_AM_UserAppRoleServices] PRIMARY KEY ([UserAppRoleServiceID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180309131313_init')
BEGIN
    CREATE TABLE [AM_UserApps] (
        [UserAppID] int NOT NULL IDENTITY,
        [AppID] int NOT NULL,
        [UserID] int NOT NULL,
        CONSTRAINT [PK_AM_UserApps] PRIMARY KEY ([UserAppID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180309131313_init')
BEGIN
    CREATE TABLE [AM_Users] (
        [UserID] int NOT NULL IDENTITY,
        [Status] int NOT NULL,
        [UserName] nvarchar(max) NULL,
        CONSTRAINT [PK_AM_Users] PRIMARY KEY ([UserID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180309131313_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180309131313_init', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180309134551_m002')
BEGIN
    CREATE TABLE [AM_InheritedRoles] (
        [InheritedRolesID] int NOT NULL IDENTITY,
        [AppRoleServiceID] int NOT NULL,
        CONSTRAINT [PK_AM_InheritedRoles] PRIMARY KEY ([InheritedRolesID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180309134551_m002')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180309134551_m002', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180312110710_m003')
BEGIN
    EXEC sp_rename N'AM_AppRoleServices.AppRoleID', N'AppRoleServiceID', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180312110710_m003')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180312110710_m003', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180312174856_m004')
BEGIN
    EXEC sp_rename N'AM_UserAppRoleServices.AppRoleServiceID', N'AppRoleID', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180312174856_m004')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180312174856_m004', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180312203405_m005')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180312203405_m005', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180313144336_m006')
BEGIN
    EXEC sp_rename N'AM_InheritedRoles.AppRoleServiceID', N'RoleID', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180313144336_m006')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180313144336_m006', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180315151908_m007')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'AM_Services') AND [c].[name] = N'AppID');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [AM_Services] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [AM_Services] DROP COLUMN [AppID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180315151908_m007')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180315151908_m007', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180316175651_m008')
BEGIN
    EXEC sp_rename N'AM_UserAppRoleServices.AppRoleID', N'RoleID', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180316175651_m008')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180316175651_m008', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180411160930_m009')
BEGIN
    ALTER TABLE [AM_Users] ADD [FirstName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180411160930_m009')
BEGIN
    ALTER TABLE [AM_Users] ADD [LastName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180411160930_m009')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180411160930_m009', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180411182719_m010')
BEGIN
    ALTER TABLE [AM_Applications] ADD [AppSecurityKey] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180411182719_m010')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180411182719_m010', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180412122141_m011')
BEGIN
    ALTER TABLE [AM_Applications] ADD [AppUrl] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180412122141_m011')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180412122141_m011', N'2.0.1-rtm-125');
END;

GO

