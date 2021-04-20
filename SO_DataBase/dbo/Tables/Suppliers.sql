CREATE TABLE [dbo].[Suppliers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SupplierName] NVARCHAR(125) NOT NULL, 
    [Address] NVARCHAR(250) NULL, 
    [StateProvince] NVARCHAR(2) NULL, 
    [City] NVARCHAR(50) NULL, 
    [Contact Person] NVARCHAR(50) NULL, 
    [Phone] NVARCHAR(10) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Fax] NVARCHAR(50) NULL
)
