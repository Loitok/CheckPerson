CREATE TABLE [dbo].[Ticket] (
    [TicketId]     INT             IDENTITY (1, 1) NOT NULL,
    [TicketNumber] NVARCHAR (20)   NOT NULL,
    [PurchasedAt]  DATETIME2 (7)   NOT NULL,
    [SeatNumber]   NVARCHAR (20)   NOT NULL,
    [Class]        NVARCHAR (15)   NOT NULL,
    [TotalAmount]  DECIMAL (18, 2) NOT NULL,
    [FlightId]     INT             NOT NULL,
    [ClientId]     INT             NOT NULL,
    CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED ([TicketId] ASC),
    CONSTRAINT [FK_Ticket_Client_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([ClientId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Ticket_Flight_FlightId] FOREIGN KEY ([FlightId]) REFERENCES [dbo].[Flight] ([FlightId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Ticket_ClientId]
    ON [dbo].[Ticket]([ClientId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Ticket_FlightId]
    ON [dbo].[Ticket]([FlightId] ASC);

