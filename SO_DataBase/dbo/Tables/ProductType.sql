CREATE TABLE [dbo].[ProductType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TypeName] NVARCHAR(50) NOT NULL, 
    [ProductClass_Id] INT NOT NULL, 
    CONSTRAINT [FK_SubType_ToGeneralType] FOREIGN KEY ([ProductClass_Id]) REFERENCES [ProductClass]([Id])
)
