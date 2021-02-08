CREATE PROCEDURE [dbo].[spGetGenType_ById]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id,TypeName
	FROM dbo.GeneralType
	WHERE Id = @id;
END
