CREATE TABLE [dbo].[Airport] (
    [AirportId]   INT           IDENTITY (1, 1) NOT NULL,
    [AirportName] NVARCHAR (50) NOT NULL,
    [City]        NVARCHAR (50) NOT NULL,
    [TimeZone]    NVARCHAR (4)  NOT NULL,
    CONSTRAINT [PK_Airport] PRIMARY KEY CLUSTERED ([AirportId] ASC)
);

