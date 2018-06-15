CREATE TABLE [dbo].[AM_Users] (
    [UserID]    INT            IDENTITY (1, 1) NOT NULL,
    [UserName]  NVARCHAR (MAX) NULL,
    [FirstName] NVARCHAR (MAX) NULL,
    [LastName]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AM_Users] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

