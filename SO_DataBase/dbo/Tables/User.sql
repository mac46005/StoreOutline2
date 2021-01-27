CREATE TABLE [dbo].[User]
(
	[Id] NVARCHAR(450) NOT NULL PRIMARY KEY, 
    [Email] NVARCHAR(MAX) NOT NULL, 
    [PhoneNumber] NVARCHAR(11) NULL,
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [CreateDate] DATETIME2 NOT NULL, 
    [Birthday] DATETIME2 NULL
)
