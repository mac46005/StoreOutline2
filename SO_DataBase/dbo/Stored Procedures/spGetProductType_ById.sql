CREATE PROCEDURE [dbo].[spGetProductType_ById]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id,[TypeName],Class_Id
	FROM dbo.ProductType
	WHERE Id = @id;
END
