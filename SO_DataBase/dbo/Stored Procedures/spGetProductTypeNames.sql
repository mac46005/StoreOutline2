CREATE PROCEDURE [dbo].[spGetProductTypeNames]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT [TypeName]
	FROM dbo.ProductType
END
