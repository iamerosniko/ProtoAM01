CREATE TABLE [dbo].[AM_UserAppRoleServices] (
    [UserAppRoleServiceID] INT IDENTITY (1, 1) NOT NULL,
    [RoleID]               INT NOT NULL,
    [UserAppID]            INT NOT NULL,
    CONSTRAINT [PK_AM_UserAppRoleServices] PRIMARY KEY CLUSTERED ([UserAppRoleServiceID] ASC)
);

