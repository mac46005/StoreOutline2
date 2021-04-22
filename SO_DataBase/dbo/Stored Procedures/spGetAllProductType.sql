CREATE PROCEDURE [dbo].[spGetAllProductType]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, [TypeName], Class_Id
	FROM dbo.ProductType
END
