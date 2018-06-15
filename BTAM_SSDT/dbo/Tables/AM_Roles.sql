CREATE TABLE [dbo].[AM_Roles] (
    [RoleID]   INT            IDENTITY (1, 1) NOT NULL,
    [RoleName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AM_Roles] PRIMARY KEY CLUSTERED ([RoleID] ASC)
);

