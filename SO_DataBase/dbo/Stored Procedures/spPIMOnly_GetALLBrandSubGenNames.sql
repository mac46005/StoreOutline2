CREATE PROCEDURE [dbo].[spPIMOnly_GetALLBrandSubGenNames]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Name]
	FROM dbo.BrandDetail
	UNION
	SELECT TypeName
	FROM dbo.GeneralType
	UNION
	SELECT SubTypeName
	FROM dbo.SubType
END
