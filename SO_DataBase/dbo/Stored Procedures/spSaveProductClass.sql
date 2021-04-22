CREATE PROCEDURE [dbo].[spSaveProductClass]
	@className NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.ProductClass(ClassName)
	VALUES(@className)
END
