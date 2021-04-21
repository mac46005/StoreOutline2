CREATE PROCEDURE [dbo].[spGetProductTypeNames]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Type]
	FROM dbo.ProductType
END
