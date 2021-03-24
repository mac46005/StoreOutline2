CREATE PROCEDURE [dbo].[spGetGenDetail_ById]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM GeneralDetails
	WHERE Id = @id;
END
