CREATE PROCEDURE [dbo].[spPIMOnly_GetALLBrandTypeClassNames]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Name]
	FROM dbo.BrandDetail
	UNION
	SELECT Class
	FROM dbo.ProductClass
	UNION
	SELECT [Type]
	FROM dbo.ProductType
END
