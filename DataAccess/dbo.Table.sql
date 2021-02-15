CREATE TABLE [dbo].[Cars]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [BrandId] INT NULL, 
    [ColorId] INT NULL, 
    [ModelYear] SMALLINT NULL, 
    [DailyPrice] DECIMAL NULL, 
    [Description] NVARCHAR(50) NULL
)
