CREATE PROCEDURE [dbo].[spDeleteSubType]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE
	FROM dbo.SubType
	WHERE Id = @id;
END
