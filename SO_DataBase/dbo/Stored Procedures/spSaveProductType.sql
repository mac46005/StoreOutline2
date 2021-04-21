CREATE PROCEDURE [dbo].[spSaveProductType]
	@type nvarchar(50),
	@class_Id int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.ProductType([Type],Class_Id)
	VALUES(@type,@class_Id);
END
