CREATE TABLE [dbo].[AM_ServiceAttributes] (
    [ServiceAttributeID] INT            IDENTITY (1, 1) NOT NULL,
    [ServiceID]          INT            NOT NULL,
    [AttribDesc]         NVARCHAR (MAX) NULL,
    [AttribName]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AM_ServiceAttributes] PRIMARY KEY CLUSTERED ([ServiceAttributeID] ASC)
);

