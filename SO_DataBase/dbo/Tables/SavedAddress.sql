CREATE TABLE [dbo].[SavedAddress]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [User_Id] NVARCHAR(450) NOT NULL, 
    [StreetAddress] NVARCHAR(MAX) NOT NULL, 
    [Zip] NVARCHAR(50) NOT NULL, 
    [State] NVARCHAR(2) NOT NULL, 
    CONSTRAINT [FK_SavedAddress_ToUser] FOREIGN KEY ([User_Id]) REFERENCES [User]([Id])
)
