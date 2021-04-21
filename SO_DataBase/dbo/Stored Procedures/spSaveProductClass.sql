CREATE PROCEDURE [dbo].[spSaveProductClass]
	@class NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.ProductClass(Class)
	VALUES(@class)
END
