CREATE TABLE [dbo].[FavoriteProducts]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [User_Id] NVARCHAR(450) NOT NULL, 
    [Product_Id] INT NOT NULL, 
    CONSTRAINT [FK_FavoriteProducts_ToProduct] FOREIGN KEY ([Product_Id]) REFERENCES [Product]([Id])
)
