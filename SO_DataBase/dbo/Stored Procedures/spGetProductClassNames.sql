CREATE PROCEDURE [dbo].[spGetProductClassNames]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ClassName
	FROM dbo.ProductClass
END
