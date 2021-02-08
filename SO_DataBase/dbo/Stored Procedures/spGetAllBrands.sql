CREATE PROCEDURE [dbo].[spGetAllBrands]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id,[Name],[Description]
	FROM dbo.BrandDetail
END
