CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductName] NVARCHAR(128) NOT NULL,
    [Product_SerialNumber] nvarchar(128),
    [GeneralDetails_Id] INT NULL, 
    [RetailPrice] MONEY NOT NULL, 
    [Tax_Id] INT NOT NULL, 
    [QuantityStock] INT NULL DEFAULT 0, 
    [IsAvailable] BIT NULL, 
    [CreateDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    [LastModified] DATETIME2 NOT NULL, 
    [Supplier_Id] INT NULL, 
    CONSTRAINT [FK_Product_ToGeneralDetails] FOREIGN KEY ([GeneralDetails_Id]) REFERENCES [GeneralDetails]([Id]), 
)
