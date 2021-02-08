CREATE PROCEDURE [dbo].[spDeleteGenType]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE
	FROM dbo.GeneralType
	WHERE Id = @id;
END
