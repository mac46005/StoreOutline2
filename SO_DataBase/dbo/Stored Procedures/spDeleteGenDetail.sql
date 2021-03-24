CREATE PROCEDURE [dbo].[spDeleteGenDetail]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM GeneralDetails
	WHERE Id = @id;
END
