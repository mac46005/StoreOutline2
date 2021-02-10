CREATE TABLE [dbo].[GeneralDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Brand_Id] INT NOT NULL, 
    [GeneralType_Id] INT NOT NULL, 
    [SubType_Id] INT NOT NULL, 
    CONSTRAINT [FK_GeneralDetails_ToBrand] FOREIGN KEY ([Brand_Id]) REFERENCES [BrandDetail]([Id]), 
    CONSTRAINT [FK_GeneralDetails_ToGeneralType] FOREIGN KEY ([GeneralType_Id]) REFERENCES [GeneralType]([Id]), 
    CONSTRAINT [FK_GeneralDetails_ToSubType] FOREIGN KEY ([SubType_Id]) REFERENCES [SubType]([Id])
)
