CREATE PROCEDURE [dbo].[spDeletebrand]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE
	FROM dbo.BrandDetail
	WHERE Id = @id
END