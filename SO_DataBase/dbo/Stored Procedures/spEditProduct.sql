CREATE PROCEDURE [dbo].[spEditProduct]
    @id int,
	@productName nvarchar(128),
	@product_SerialNumber nvarchar(128),
	@generalDetails_Id int,
	@retailPrice money,
	@tax_Id int,
	@quantityStock int,
	@isAvailable bit,
	@createDate datetime2(7),
	@lastModified datetime2(7)
AS
	SET NOCOUNT ON;
	
	UPDATE dbo.Products
	SET 
	ProductName = @productName,
	Product_SerialNumber = @product_SerialNumber,
	GeneralDetails_Id = @generalDetails_Id,
	RetailPrice = @retailPrice,
	Tax_Id = @tax_Id,
	QuantityStock = @quantityStock,
	IsAvailable = @isAvailable,
	LastModified = @lastModified
	WHERE Id = @id
RETURN 0
