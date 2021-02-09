CREATE PROCEDURE [dbo].[spGetBrandNames]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Name]
	FROM dbo.BrandDetail
END
