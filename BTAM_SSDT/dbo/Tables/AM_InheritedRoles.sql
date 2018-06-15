CREATE TABLE [dbo].[AM_InheritedRoles] (
    [InheritedRolesID] INT IDENTITY (1, 1) NOT NULL,
    [RoleID]           INT NOT NULL,
    [MainRoleID]       INT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AM_InheritedRoles] PRIMARY KEY CLUSTERED ([InheritedRolesID] ASC)
);

