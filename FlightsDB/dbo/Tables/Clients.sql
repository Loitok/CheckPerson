CREATE TABLE [dbo].[Client] (
    [ClientId]    INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (20) NOT NULL,
    [LastName]    NVARCHAR (20) NOT NULL,
    [Gender]      NVARCHAR (10) NOT NULL,
    [Address]     NVARCHAR (50) NOT NULL,
    [DateOfBirth] DATETIME2 (7) NOT NULL,
    [Email]       NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([ClientId] ASC)
);

