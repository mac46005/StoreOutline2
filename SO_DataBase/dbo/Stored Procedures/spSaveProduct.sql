CREATE PROCEDURE [dbo].[spSaveProduct]
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
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Product(
	ProductName,Product_SerialNumber,
	GeneralDetails_Id,RetailPrice,
	Tax_Id,QuantityStock,IsAvailable,
	CreateDate,LastModified
	)
	VALUES(
	@productName,@product_SerialNumber,
	@generalDetails_Id,@retailPrice,
	@tax_Id,@quantityStock,@isAvailable,
	@createDate,@lastModified
	)
END
