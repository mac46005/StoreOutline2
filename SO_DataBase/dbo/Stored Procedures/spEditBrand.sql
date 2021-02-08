CREATE PROCEDURE [dbo].[spEditBrand]
	@id int,
	@name NVARCHAR(200),
	@description NVARCHAR(1500)
AS
	SET NOCOUNT ON;
	UPDATE dbo.BrandDetail
	SET [Name] = @name,[Description] = @description
	WHERE Id = @id;
RETURN 0
