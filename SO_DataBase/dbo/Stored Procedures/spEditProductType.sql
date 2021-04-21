CREATE PROCEDURE [dbo].[EditProductType]
	@id int,
	@type nvarchar(50),
	@class_Id int
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE dbo.ProductType
	SET [Type] = @type, class_Id = @class_Id
	WHERE Id = @id
END
