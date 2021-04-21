CREATE PROCEDURE [dbo].[spGetAllProductType]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, [Type], Class_Id
	FROM dbo.ProductType
END
