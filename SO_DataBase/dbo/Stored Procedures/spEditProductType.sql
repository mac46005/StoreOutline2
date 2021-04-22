CREATE PROCEDURE [dbo].[EditProductType]
	@id int,
	@typeName nvarchar(50),
	@class_Id int
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE dbo.ProductType
	SET [TypeName] = @typeName, ProductClass_Id = @class_Id
	WHERE Id = @id
END
