CREATE TABLE [dbo].[AM_UserApps] (
    [UserAppID] INT IDENTITY (1, 1) NOT NULL,
    [AppID]     INT NOT NULL,
    [UserID]    INT NOT NULL,
    CONSTRAINT [PK_AM_UserApps] PRIMARY KEY CLUSTERED ([UserAppID] ASC)
);

