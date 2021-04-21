CREATE PROCEDURE [dbo].[spDeleteProductClass]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE
	FROM dbo.ProductClass
	WHERE Id = @id;
END
