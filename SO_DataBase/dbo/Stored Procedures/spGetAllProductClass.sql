CREATE PROCEDURE [dbo].[spGetAllProductClass]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, ClassName
	FROM dbo.ProductClass;
END
