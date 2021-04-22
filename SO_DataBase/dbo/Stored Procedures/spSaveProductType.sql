CREATE PROCEDURE [dbo].[spSaveProductType]
	@typeName nvarchar(50),
	@class_Id int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.ProductType([TypeName],Class_Id)
	VALUES(@typeName,@class_Id);
END
