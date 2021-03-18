CREATE PROCEDURE [dbo].[spDeleteProduct]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [Products]
	WHERE Id = @id
END
