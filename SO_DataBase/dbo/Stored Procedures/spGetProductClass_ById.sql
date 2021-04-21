CREATE PROCEDURE [dbo].[spGetProductClass_ById]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id,Class
	FROM dbo.ProductClass
	WHERE Id = @id;
END
