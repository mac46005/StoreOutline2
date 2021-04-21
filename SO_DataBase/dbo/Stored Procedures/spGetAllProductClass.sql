CREATE PROCEDURE [dbo].[spGetAllProductClass]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, Class
	FROM dbo.ProductClass;
END
