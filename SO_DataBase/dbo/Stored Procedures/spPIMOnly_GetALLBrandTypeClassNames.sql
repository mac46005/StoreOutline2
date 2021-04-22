CREATE PROCEDURE [dbo].[spPIMOnly_GetAllBrandTypeClassNames]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Name]
	FROM dbo.BrandDetail
	UNION
	SELECT ClassName
	FROM dbo.ProductClass
	UNION
	SELECT [TypeName]
	FROM dbo.ProductType
END
