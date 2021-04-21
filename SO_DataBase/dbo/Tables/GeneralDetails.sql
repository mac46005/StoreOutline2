CREATE TABLE [dbo].[GeneralDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Brand_Id] INT NOT NULL, 
    [Class_Id] INT NOT NULL, 
    [Type_Id] INT NOT NULL, 
    CONSTRAINT [FK_GeneralDetails_ToBrand] FOREIGN KEY ([Brand_Id]) REFERENCES [BrandDetail]([Id]), 
    CONSTRAINT [FK_GeneralDetails_ToProductClass] FOREIGN KEY ([Class_Id]) REFERENCES [ProductClass]([Id]), 
    CONSTRAINT [FK_GeneralDetails_ToSubType] FOREIGN KEY ([Type_Id]) REFERENCES [ProductType]([Id])
)
