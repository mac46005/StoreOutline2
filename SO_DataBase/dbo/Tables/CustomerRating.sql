CREATE TABLE [dbo].[CustomerRating]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [User_Id] NVARCHAR(450) NULL, 
    [Product_Id] INT NOT NULL, 
    [Description] NVARCHAR(1000) NOT NULL, 
    [Rating] INT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_CustomerRating_ToUser] FOREIGN KEY ([User_Id]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_CustomerRating_ToProduct] FOREIGN KEY ([Product_Id]) REFERENCES [Products]([Id])
)
