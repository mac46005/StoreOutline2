CREATE TABLE [dbo].[SubCategories]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Categories_Id] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_SubCategories_ToCategories] FOREIGN KEY ([Categories_Id]) REFERENCES [Categories]([Id])
)
