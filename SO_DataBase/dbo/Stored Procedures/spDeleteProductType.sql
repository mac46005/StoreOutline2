CREATE PROCEDURE [dbo].[spDeleteProductType]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE
	FROM dbo.ProductType
	WHERE Id = @id;
END
