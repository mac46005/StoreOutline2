CREATE PROCEDURE [dbo].[spEditProductClass]
	@id int,
	@className NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.ProductClass
	SET ClassName = @className
	WHERE Id = @id
END
