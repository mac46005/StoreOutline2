CREATE TABLE [dbo].[PaymentType]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [User_Id] NVARCHAR(450) NOT NULL, 
    [CardType] NVARCHAR(50) NOT NULL, 
    [CardNumber] NVARCHAR(50) NOT NULL, 
    [ExpirationMonth] INT NOT NULL, 
    [ExpirationYear] INT NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Phone] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_PaymentType_ToUser] FOREIGN KEY ([User_Id]) REFERENCES [User]([Id])
)
