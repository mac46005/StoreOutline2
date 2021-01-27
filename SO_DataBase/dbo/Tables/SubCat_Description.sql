CREATE TABLE [dbo].[SubCat_Description]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SubCategory_Id] INT NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_SubCat_Description_ToSubCategories] FOREIGN KEY ([SubCategory_Id]) REFERENCES [SubCategories]([Id])
)
