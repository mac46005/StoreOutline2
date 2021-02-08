CREATE PROCEDURE [dbo].[spGetBrand_ById]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id,[Name],[Description]
	FROM dbo.BrandDetail
	WHERE Id = @id;
END
