CREATE TABLE [dbo].[AM_Applications] (
    [AppID]          INT            IDENTITY (1, 1) NOT NULL,
    [AppMemberName]  NVARCHAR (MAX) NULL,
    [AppName]        NVARCHAR (MAX) NULL,
    [AppSecurityKey] NVARCHAR (MAX) NULL,
    [AppUrl]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AM_Applications] PRIMARY KEY CLUSTERED ([AppID] ASC)
);

