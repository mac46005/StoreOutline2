CREATE TABLE [dbo].[SubType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SubTypeName] NVARCHAR(50) NOT NULL, 
    [GeneralType_Id] INT NOT NULL, 
    CONSTRAINT [FK_SubType_ToGeneralType] FOREIGN KEY ([GeneralType_Id]) REFERENCES [GeneralType]([Id])
)
