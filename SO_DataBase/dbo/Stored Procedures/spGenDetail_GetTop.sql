CREATE PROCEDURE [dbo].[spGenDetail_GetTop]
	@amount int
AS
BEGIN 
	SET NOCOUNT ON;

	SELECT TOP(@amount) *
	FROM GeneralDetails;
END
