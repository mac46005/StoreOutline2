CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProductName] NVARCHAR(128) NOT NULL, 
    [GeneralDetails_Id] INT NOT NULL, 
    [RetailPrice] MONEY NOT NULL, 
    [Tax_Id] INT NOT NULL, 
    [QuantityStock] INT NOT NULL DEFAULT 0, 
    [IsAvailable] BIT NOT NULL, 
    [CreateDate] DATETIME2 NOT NULL, 
    [LastModified] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_Product_ToGeneralDetails] FOREIGN KEY ([GeneralDetails_Id]) REFERENCES [GeneralDetails]([Id]), 
)
