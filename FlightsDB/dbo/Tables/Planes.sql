CREATE TABLE [dbo].[Plane] (
    [PlaneId]  INT           IDENTITY (1, 1) NOT NULL,
    [Model]    NVARCHAR (20) NOT NULL,
    [MaxRange] INT           NOT NULL,
    CONSTRAINT [PK_Plane] PRIMARY KEY CLUSTERED ([PlaneId] ASC)
);

