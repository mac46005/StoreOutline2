CREATE TABLE [dbo].[ProductType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Type] NVARCHAR(50) NOT NULL, 
    [Class_Id] INT NOT NULL, 
    CONSTRAINT [FK_SubType_ToGeneralType] FOREIGN KEY ([Class_Id]) REFERENCES [ProductClass]([Id])
)
