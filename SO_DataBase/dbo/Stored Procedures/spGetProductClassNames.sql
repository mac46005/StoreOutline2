CREATE PROCEDURE [dbo].[spGetProductClassNames]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Class
	FROM dbo.ProductClass
END
