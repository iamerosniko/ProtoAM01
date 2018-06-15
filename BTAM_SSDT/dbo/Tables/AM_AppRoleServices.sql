CREATE TABLE [dbo].[AM_AppRoleServices] (
    [AppRoleServiceID] INT IDENTITY (1, 1) NOT NULL,
    [AppID]            INT NOT NULL,
    [RoleID]           INT NOT NULL,
    CONSTRAINT [PK_AM_AppRoleServices] PRIMARY KEY CLUSTERED ([AppRoleServiceID] ASC)
);

