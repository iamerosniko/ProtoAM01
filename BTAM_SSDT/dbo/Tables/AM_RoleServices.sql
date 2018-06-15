CREATE TABLE [dbo].[AM_RoleServices] (
    [RoleServiceID] INT IDENTITY (1, 1) NOT NULL,
    [RoleID]        INT NOT NULL,
    [ServiceID]     INT NOT NULL,
    CONSTRAINT [PK_AM_RoleServices] PRIMARY KEY CLUSTERED ([RoleServiceID] ASC)
);

