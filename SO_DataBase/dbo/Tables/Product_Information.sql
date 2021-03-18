CREATE TABLE [dbo].[Product_Information]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Product_Id] INT NOT NULL, 
    [Categories_Id] INT NOT NULL, 
    [SubCategory_Id] INT NOT NULL, 
    [SubCat_Description] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Detailed_Information_ToProduct] FOREIGN KEY ([Product_Id]) REFERENCES [Products]([Id]), 
    CONSTRAINT [FK_Detailed_Information_ToSubCategories] FOREIGN KEY ([SubCategory_Id]) REFERENCES [SubCategories]([Id]), 
    CONSTRAINT [FK_Detailed_Information_ToCategories] FOREIGN KEY ([Categories_Id]) REFERENCES [Categories]([Id])
)
