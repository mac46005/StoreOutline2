CREATE PROCEDURE [dbo].[spGetSubType_ById]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id,SubTypeName,GeneralType_Id
	FROM dbo.SubType
	WHERE Id = @id;
END
