CREATE PROCEDURE [dbo].[spSaveBrandInfo]
	@name nvarchar(200),
	@description nvarchar(1500)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.BrandDetail([Name],[Description]) 
	VALUES(@name,@description);
END
