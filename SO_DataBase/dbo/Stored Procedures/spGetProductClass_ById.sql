CREATE PROCEDURE [dbo].[spGetProductClass_ById]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id,ClassName
	FROM dbo.ProductClass
	WHERE Id = @id;
END
