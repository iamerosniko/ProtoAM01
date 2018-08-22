CREATE TABLE [dbo].[AM_RoleServices] (
    [RoleServiceID] INT            IDENTITY (1, 1) NOT NULL,
    [RoleID]        INT            NOT NULL,
    [ServiceDesc]   NVARCHAR (MAX) NULL,
    [ServiceName]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AM_RoleServices] PRIMARY KEY CLUSTERED ([RoleServiceID] ASC)
);

