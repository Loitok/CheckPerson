CREATE TABLE [dbo].[Flight] (
    [FlightId]      INT           IDENTITY (1, 1) NOT NULL,
    [Status]        NVARCHAR (10) NOT NULL,
    [Date]          DATETIME2 (7) NOT NULL,
    [ArrivalTime]   TIME (7)      NOT NULL,
    [DepartureTime] TIME (7)      NOT NULL,
    [PlaneId]       INT           NOT NULL,
    [AirportId]     INT           NOT NULL,
    [DepartureFrom] NVARCHAR (50) NULL,
    [ArrivalTo]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_Flight] PRIMARY KEY CLUSTERED ([FlightId] ASC),
    CONSTRAINT [FK_Flight_Airport_AirportId] FOREIGN KEY ([AirportId]) REFERENCES [dbo].[Airport] ([AirportId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Flight_Plane_PlaneId] FOREIGN KEY ([PlaneId]) REFERENCES [dbo].[Plane] ([PlaneId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Flight_AirportId]
    ON [dbo].[Flight]([AirportId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Flight_PlaneId]
    ON [dbo].[Flight]([PlaneId] ASC);

