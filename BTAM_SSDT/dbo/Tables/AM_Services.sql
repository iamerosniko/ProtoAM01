CREATE TABLE [dbo].[AM_Services] (
    [ServiceID]   INT            IDENTITY (1, 1) NOT NULL,
    [ServiceDesc] NVARCHAR (MAX) NULL,
    [ServiceName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AM_Services] PRIMARY KEY CLUSTERED ([ServiceID] ASC)
);

